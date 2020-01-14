using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Aruco;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using UnityEngine;

public class WebcamInput : MonoBehaviour
{
    public WebcamSettings settings;

    public bool right, left, top, down;
    public bool action;
    public Vector2 aimPosition;

    VideoCapture webcam;
    Dictionary markerDict;
    GridBoard gridBoard;
    DetectorParameters arucoParameters;

    private void Start()
    {
        webcam = new VideoCapture(0);
        //webcam.FlipHorizontal = true;
        webcam.ImageGrabbed += HandleWebcam;

        markerDict = new Dictionary(Dictionary.PredefinedDictionaryName.Dict4X4_50);
        gridBoard = new GridBoard(4, 4, 80, 30, markerDict);
        arucoParameters = DetectorParameters.GetDefault();
    }

    private void Update()
    {
        if (webcam.IsOpened) webcam.Grab();
    }

    private void HandleWebcam(object sender, EventArgs e)
    {
        Image<Bgr, byte> origin = new Image<Bgr, byte>(webcam.Width, webcam.Height);
        if (webcam.IsOpened) webcam.Retrieve(origin);
        Mat input = new Mat();
        webcam.Retrieve(input);

        // Adapatative threshold
        Image<Gray, byte> grayscale = new Image<Gray, byte>(origin.Width, origin.Height);
        CvInvoke.CvtColor(origin, grayscale, ColorConversion.Bgr2Gray);
        CvInvoke.AdaptiveThreshold(grayscale, grayscale, 255, AdaptiveThresholdType.GaussianC, ThresholdType.BinaryInv, 11, 11);

        VectorOfInt ids = new VectorOfInt();
        VectorOfVectorOfPointF corners = new VectorOfVectorOfPointF();
        ArucoInvoke.DetectMarkers(input, markerDict, corners, ids, arucoParameters);

        Image<Bgr, byte> output = origin.Clone();
        if (ids.Size > 0)
        {
            ArucoInvoke.DrawDetectedMarkers(output, corners, ids, new MCvScalar(0, 0, 255));
            CvInvoke.Circle(output, new Point((int)corners[0][0].X, (int)corners[0][0].Y), 5, new MCvScalar(0,0,255), 2);
            CvInvoke.Circle(output, new Point((int)corners[0][1].X, (int)corners[0][1].Y), 5, new MCvScalar(0,255,0), 2);
            CvInvoke.Circle(output, new Point((int)corners[0][3].X, (int)corners[0][3].Y), 5, new MCvScalar(255,0,0), 2);
        }



        CvInvoke.Imshow("Webcam view", origin);
        //CvInvoke.Imshow("Thershold view", grayscale);
        CvInvoke.Imshow("Output view", output);
        // CvInvoke.Imshow("Shape detection view", shapeDetection);
    }

    private void OnDestroy()
    {
        webcam.Dispose();
        CvInvoke.DestroyAllWindows();
    }
}
