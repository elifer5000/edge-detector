using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdgeDetector
{
  public partial class Form1 : Form
  {
    Filter _Filter;
    private Bitmap mBitmap;
    private Bitmap mBitmapForUndo;
    private double Zoom = 1.0;
    public Form1()
    {
      InitializeComponent();
      //panel1.Parent = this;
      this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

      this.MouseWheel += new MouseEventHandler(panel1_MouseWheel);
      //this.panel1.MouseMove += new MouseEventHandler(panel1_MouseWheel);

    }

    private void panel1_MouseWheel(object sender, MouseEventArgs e)
    {
      if (e.Delta > 0)
        DoZoom(true);
      else if (e.Delta < 0)
        DoZoom(false);
    }
    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDlg = new OpenFileDialog();

      openFileDlg.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
      openFileDlg.FilterIndex = 2;

      if (openFileDlg.ShowDialog() == DialogResult.OK)
      {
        try
        {
          mBitmap = (Bitmap)Bitmap.FromFile(openFileDlg.FileName, false);
          mBitmapForUndo = (Bitmap)mBitmap.Clone();
          RefreshZoom();
          //toolStripProgressBar1.Minimum = 0;
          //toolStripProgressBar1.Maximum = mBitmap.Width * mBitmap.Height;
        }
        catch (Exception)
        {
          throw;
        }
      }

    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void OnPaint(object sender, PaintEventArgs e)
    {
      if (panel1.AllowPaint == false)
        return;

      Graphics G = e.Graphics;
      Rectangle PanelRect = new Rectangle(0, 0, panel1.Width, panel1.Height);
      LinearGradientBrush aLinearGradientBrush = new LinearGradientBrush(PanelRect, Color.Azure, Color.Black, 40);

      G.FillRectangle(aLinearGradientBrush, PanelRect);
      if (mBitmap != null)
      {
        Rectangle Rect = new Rectangle(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y, (int)(mBitmap.Width * Zoom), (int)(mBitmap.Height * Zoom));
        if (Rect.Width < panel1.Width)
        {
          Point Origin = Rect.Location;
          Origin.X = (panel1.Width - Rect.Width) / 2;
          Rect.Location = Origin;
        }
        if (Rect.Height < panel1.Height)
        {
          Point Origin = Rect.Location;
          Origin.Y = (panel1.Height - Rect.Height) / 2;
          Rect.Location = Origin;
        }
        G.DrawImage(mBitmap, Rect);
      }
    }

    private void sobellToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mBitmap == null)
        return;

      DateTime startTime = DateTime.Now;
      Cursor.Current = Cursors.WaitCursor;
      panel1.SuspendLayout();
      panel1.AllowPaint = false;
      _Filter = new Filter(Filter.FilterType.SobelFilter, mBitmap);
      int Thres = 100;
      try
      {
        Thres = Math.Max(Math.Min(255, Convert.ToInt32(toolStripTextBox1.Text)), 0);

      }
      catch (FormatException)
      {
        Console.WriteLine("Input string is not a sequence of digits.");
      }
      catch (OverflowException)
      {
        Console.WriteLine("The number cannot fit in an Int32.");
      }
      finally
      {
        _Filter.Threshold = Thres;
      }
      _Filter.ApplyFilter();
      panel1.AllowPaint = true;
      panel1.ResumeLayout();
      panel1.Invalidate();
      Cursor.Current = Cursors.Default;
      DateTime endTime = DateTime.Now;
      TimeSpan duration = endTime - startTime;
      toolStripStatusLabel1.Text = String.Format("Time elapsed: {0}.{1} seconds", duration.Seconds, duration.Milliseconds);

    }

    private void zoomToFitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mBitmap == null)
        return;
      Zoom = Math.Min((double)panel1.Width / (double)mBitmap.Width, (double)panel1.Height / (double)mBitmap.Height);
      RefreshZoom();

    }

    private void originalSizeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Zoom = 1.0;
      RefreshZoom();
    }

    private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DoZoom(true);
    }

    private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DoZoom(false);
    }

    private void DoZoom(bool zoomIn)
    {
      if (mBitmap == null)
        return;
      double TmpZoom = Zoom;
      if (zoomIn)
      {
        TmpZoom *= 1.5;
        if (TmpZoom < 10)
          Zoom = TmpZoom;
      }
      else
      {
        TmpZoom /= 1.5;
        if (TmpZoom > 0.01)
          Zoom = TmpZoom;
      }
      RefreshZoom();

    }

    private void RefreshZoom()
    {
      if (mBitmap == null)
        return;
      panel1.AutoScrollMinSize = new Size((int)(mBitmap.Width * Zoom), (int)(mBitmap.Height * Zoom));
      panel1.Invalidate();
    }

    private void panel1_SizeChanged(object sender, EventArgs e)
    {
      panel1.Invalidate();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void panel1_MouseEnter(object sender, EventArgs e)
    {
      //panel1.Parent.Focus();
      this.Focus();
    }

    private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mBitmap == null)
        return;

      DateTime startTime = DateTime.Now;
      Cursor.Current = Cursors.WaitCursor;
      panel1.SuspendLayout();
      panel1.AllowPaint = false;
      _Filter = new Filter(Filter.FilterType.PrewittFilter, mBitmap);
      int Thres = 100;
      try
      {
        Thres = Math.Max(Math.Min(255, Convert.ToInt32(toolStripTextBox1.Text)), 0);

      }
      catch (FormatException)
      {
        Console.WriteLine("Input string is not a sequence of digits.");
      }
      catch (OverflowException)
      {
        Console.WriteLine("The number cannot fit in an Int32.");
      }
      finally
      {
        _Filter.Threshold = Thres;
      }
      _Filter.ApplyFilter();
      panel1.AllowPaint = true;
      panel1.ResumeLayout();
      panel1.Invalidate();
      Cursor.Current = Cursors.Default;
      DateTime endTime = DateTime.Now;
      TimeSpan duration = endTime - startTime;
      toolStripStatusLabel1.Text = String.Format("Time elapsed: {0}.{1} seconds", duration.Seconds, duration.Milliseconds);

    }

    private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mBitmap == null)
        return;

      DateTime startTime = DateTime.Now;
      Cursor.Current = Cursors.WaitCursor;
      panel1.SuspendLayout();
      panel1.AllowPaint = false;
      _Filter = new Filter(Filter.FilterType.CannyFilter, mBitmap);
      int Thres = 100, lowThres = 20;
      double Sigma = 1.4;
      try
      {
        Thres = Math.Max(Math.Min(255, Convert.ToInt32(toolStripTextBox1.Text)), 0);
        lowThres = Math.Max(Math.Min(255, Convert.ToInt32(toolStripTextBox2.Text)), 0);
        Sigma = Math.Max(Math.Min(20, Convert.ToDouble(toolStripTextBox3.Text)), 0.1);
      }
      catch (FormatException)
      {
        Console.WriteLine("Input string is not a sequence of digits.");
      }
      catch (OverflowException)
      {
        Console.WriteLine("The number cannot fit in an Int32.");
      }
      finally
      {
        _Filter.Threshold = Thres;
        _Filter.LowThreshold = (lowThres > Thres) ? Thres : lowThres;
        _Filter.Sigma = Sigma;
      }
      _Filter.ApplyCanny();
      panel1.AllowPaint = true;
      panel1.ResumeLayout();
      panel1.Invalidate();
      Cursor.Current = Cursors.Default;
      DateTime endTime = DateTime.Now;
      TimeSpan duration = endTime - startTime;
      toolStripStatusLabel1.Text = String.Format("Time elapsed: {0}.{1} seconds", duration.Seconds, duration.Milliseconds);
    }

    private void undoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mBitmapForUndo != null)
      {
        mBitmap = (Bitmap)mBitmapForUndo.Clone();
        panel1.Invalidate();
      }
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      mBitmap.Dispose();
      mBitmap = null;
      mBitmapForUndo.Dispose();
      mBitmapForUndo = null;
      panel1.Invalidate();
    }

    private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mBitmap == null)
        return;
      DateTime startTime = DateTime.Now;
      Cursor.Current = Cursors.WaitCursor;
      panel1.SuspendLayout();
      panel1.AllowPaint = false;
      _Filter = new Filter(Filter.FilterType.NoEdgeDetection, mBitmap);
      _Filter.ConvertToGrayScale();
      panel1.AllowPaint = true;
      panel1.ResumeLayout();
      panel1.Invalidate();
      Cursor.Current = Cursors.Default;
      DateTime endTime = DateTime.Now;
      TimeSpan duration = endTime - startTime;
      toolStripStatusLabel1.Text = String.Format("Time elapsed: {0}.{1} seconds", duration.Seconds, duration.Milliseconds);
    }

    private void blurToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mBitmap == null)
        return;
      DateTime startTime = DateTime.Now;
      Cursor.Current = Cursors.WaitCursor;
      panel1.SuspendLayout();
      panel1.AllowPaint = false;
      _Filter = new Filter(Filter.FilterType.NoEdgeDetection, mBitmap);
      double Sigma = 1.4;
      try
      {
        Sigma = Math.Max(Math.Min(20.0, Convert.ToDouble(toolStripTextBox3.Text)), 0.1);

      }
      catch (FormatException)
      {
        Console.WriteLine("Input string is not a sequence of digits.");
      }
      catch (OverflowException)
      {
        Console.WriteLine("The number cannot fit in an Int32.");
      }
      finally
      {
        _Filter.Sigma = Sigma;
      }
      _Filter.MakeGaussianBlurMatrix();
      _Filter.ApplyGaussian();
      panel1.AllowPaint = true;
      panel1.ResumeLayout();
      panel1.Invalidate();
      Cursor.Current = Cursors.Default;
      DateTime endTime = DateTime.Now;
      TimeSpan duration = endTime - startTime;
      toolStripStatusLabel1.Text = String.Format("Time elapsed: {0}.{1} seconds", duration.Seconds, duration.Milliseconds);
    }

    private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mBitmap == null)
        return;
      DateTime startTime = DateTime.Now;
      Cursor.Current = Cursors.WaitCursor;
      panel1.SuspendLayout();
      panel1.AllowPaint = false;
      _Filter = new Filter(Filter.FilterType.NoEdgeDetection, mBitmap);
      _Filter.MakeGaussianSharpenMatrix();
      _Filter.ApplyGaussian();
      panel1.AllowPaint = true;
      panel1.ResumeLayout();
      panel1.Invalidate();
      Cursor.Current = Cursors.Default;
      DateTime endTime = DateTime.Now;
      TimeSpan duration = endTime - startTime;
      toolStripStatusLabel1.Text = String.Format("Time elapsed: {0}.{1} seconds", duration.Seconds, duration.Milliseconds);
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDlg = new SaveFileDialog();

      saveFileDlg.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
      saveFileDlg.FilterIndex = 2;
      saveFileDlg.OverwritePrompt = true;
      if (saveFileDlg.ShowDialog() == DialogResult.OK)
      {
        mBitmap.Save(saveFileDlg.FileName);
      }
    }

    private void invertToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (mBitmap == null)
        return;
      DateTime startTime = DateTime.Now;
      Cursor.Current = Cursors.WaitCursor;
      panel1.SuspendLayout();
      panel1.AllowPaint = false;
      _Filter = new Filter(Filter.FilterType.NoEdgeDetection, mBitmap);
      _Filter.Invert();
      panel1.AllowPaint = true;
      panel1.ResumeLayout();
      panel1.Invalidate();
      Cursor.Current = Cursors.Default;
      DateTime endTime = DateTime.Now;
      TimeSpan duration = endTime - startTime;
      toolStripStatusLabel1.Text = String.Format("Time elapsed: {0}.{1} seconds", duration.Seconds, duration.Milliseconds);
    }
  }

  public class DoubleBufferPanel : Panel
  {
    public bool AllowPaint { get; set; }
    public DoubleBufferPanel()
    {
      AllowPaint = true;
      // Set the value of the double-buffering style bits to true.
      this.SetStyle(ControlStyles.DoubleBuffer |
      ControlStyles.UserPaint |
      ControlStyles.AllPaintingInWmPaint,
      true);

      this.UpdateStyles();
    }
  }
  public class Filter
  {
    public enum FilterType { NoEdgeDetection, SobelFilter, PrewittFilter, CannyFilter, CustomConvMatrix };
    double[,] ConvMatrix_Gx;
    double[,] ConvMatrix_Gy;
    double[,] Gaussian;
    FilterType mFilterType;
    Bitmap Bmp;
    public double Threshold { get; set; }
    public double LowThreshold { get; set; }
    public double Sigma { get; set; }
    int FilterSize = 3;
    int BytesPerPixel = 0;
    Rectangle BmpRect;
    BitmapData bmpData;
    byte[] rgbValues;
    byte[] dstValues;
    double[,,] Gradients;
    byte[,,] Orientations;
    double MaxGradient;

    public Filter(FilterType filterType, Bitmap bmp)
    {
      Threshold = 100;
      LowThreshold = 20;
      Sigma = 1.4;
      mFilterType = filterType;
      Bmp = bmp;

      switch (filterType)
      {
        case FilterType.CannyFilter:
        case FilterType.SobelFilter:
          FilterSize = 3;
          ConvMatrix_Gx = new double[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
          ConvMatrix_Gy = new double[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
          break;
        case FilterType.PrewittFilter:
          FilterSize = 3;
          ConvMatrix_Gx = new double[,] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
          ConvMatrix_Gy = new double[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
          break;
      }

      BmpRect = new Rectangle(0, 0, Bmp.Width, Bmp.Height);

      try
      {
        switch (Bmp.PixelFormat)
        {
          case PixelFormat.Format32bppArgb:
            BytesPerPixel = 4;
            break;
          case PixelFormat.Format24bppRgb:
            BytesPerPixel = 3;
            break;
          case PixelFormat.Format8bppIndexed:
            BytesPerPixel = 1;
            break;
          default:
            throw new Exception("Unsupported format");
        }
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }

    private bool LockBitmap()
    {
      if (Bmp == null)
        return false;
      bmpData = Bmp.LockBits(BmpRect, ImageLockMode.ReadWrite, Bmp.PixelFormat);
      // Get the address of the first line.
      IntPtr ptr = bmpData.Scan0;

      // Declare an array to hold the bytes of the bitmap.
      int bytes = bmpData.Stride * Bmp.Height;
      rgbValues = new byte[bytes];
      // Copy the RGB values into the array. (actually, BGR)
      System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

      return true;
    }

    private void UnlockBitmap(ref byte[] destination)
    {
      IntPtr ptr = bmpData.Scan0;
      int bytes = bmpData.Stride * Bmp.Height;
      // Copy the RGB values back to the bitmap
      System.Runtime.InteropServices.Marshal.Copy(destination, 0, ptr, bytes);
      Bmp.UnlockBits(bmpData);
    }

    public void ApplyCanny()
    {
      if (!LockBitmap())
        return;

      // 1st Step - Blur and sharpen image
      MakeGaussianBlurMatrix();
      GaussianInternal();
      rgbValues = (byte[])dstValues.Clone(); // Update source
      MakeGaussianSharpenMatrix();
      GaussianInternal();
      rgbValues = (byte[])dstValues.Clone(); // Update source

      // 2nd Step - Apply Sobel filter
      ApplyInternal();
      // 3rd Step - Supress non maxima
      SupressNonMaxima();
      rgbValues = (byte[])dstValues.Clone(); // Update source
      // 4st Step - Hysteresis
      Hysteresis();
      rgbValues = (byte[])dstValues.Clone(); // Update source
      InvertInternal();

      UnlockBitmap(ref dstValues);
    }

    public void Invert()
    {
      if (!LockBitmap())
        return;

      // Declare an array to hold the bytes of the bitmap.
      int bytes = bmpData.Stride * Bmp.Height;
      dstValues = new byte[bytes];
      dstValues = rgbValues;

      InvertInternal();

      UnlockBitmap(ref dstValues);
    }

    private void InvertInternal()
    {
      int StartX = BmpRect.Left + 1;
      int StartY = BmpRect.Top + 1;
      int EndX = BmpRect.Left + BmpRect.Width - 1;
      int EndY = BmpRect.Top + BmpRect.Height - 1;

      for (int Y = StartY; Y < EndY; Y++)
        for (int X = StartX; X < EndX; X++)
        {
          int ByteStart = Y * bmpData.Stride + X * BytesPerPixel;

          for (int p = 0; p < BytesPerPixel; p++)
          {
            int ByteLoc = ByteStart + p;
            dstValues[ByteLoc] = (byte)(255 - dstValues[ByteLoc]);
          }
        }
    }

    private void Hysteresis()
    {
      int StartX = BmpRect.Left + 1;
      int StartY = BmpRect.Top + 1;
      int EndX = BmpRect.Left + BmpRect.Width - 1;
      int EndY = BmpRect.Top + BmpRect.Height - 1;

      for (int Y = StartY; Y < EndY; Y++)
        for (int X = StartX; X < EndX; X++)
        {
          int ByteStart = Y * bmpData.Stride + X * BytesPerPixel;

          for (int p = 0; p < BytesPerPixel; p++)
          {
            int ByteLoc = ByteStart + p;
            if (rgbValues[ByteLoc] < Threshold)
            {
              if (rgbValues[ByteLoc] < LowThreshold)
                rgbValues[ByteLoc] = dstValues[ByteLoc] = 0;
              else // if between thresholds, check neighbours
              {
                bool foundHighThresNeighbour = false;
                for (int i = 0; i < 3; i++)
                {
                  for (int j = 0; j < 3; j++)
                  {
                    if (i == 1 && j == 1)
                      continue; // don't check against self
                    int NeighByte = ByteLoc + bmpData.Stride * (i - 1)
                                            + BytesPerPixel * (j - 1);
                    if (rgbValues[NeighByte] > Threshold)
                    {
                      foundHighThresNeighbour = true;
                      break;
                    }
                  }
                  if (foundHighThresNeighbour)
                    break;
                }
                if (!foundHighThresNeighbour)
                  rgbValues[ByteLoc] = dstValues[ByteLoc] = 0;
								else
									rgbValues[ByteLoc] = dstValues[ByteLoc] = 255;
              }
            }
            else
              dstValues[ByteLoc] = 255;
          }
        }
    }

    private double GaussianFunc(double x, double y)
    {
      return Math.Exp(-(x * x + y * y) / (2 * Sigma * Sigma)) / Math.Sqrt(2 * Math.PI * Sigma * Sigma);
    }

    public void MakeGaussianBlurMatrix()
    {
      Sigma = Math.Max(0.1, Math.Min(20.0, Sigma));
      Gaussian = new double[5, 5];
      double Weight = 0;
      for (int i = 0; i < 5; i++)
        for (int j = 0; j < 5; j++)
        {
          Gaussian[i, j] = GaussianFunc(i - 2, j - 2);
          Weight += Gaussian[i, j];
        }
      // Normalize
      for (int i = 0; i < 5; i++)
        for (int j = 0; j < 5; j++)
          Gaussian[i, j] /= Weight;
    }

    public void MakeGaussianSharpenMatrix()
    {
      //Sigma = Math.Max(0.1, Math.Min(20.0, Sigma));
      Gaussian = new double[3, 3] {{0, -1.0/5.0, 0}, 
                                    {-1.0/5.0, 1+4.0/5.0, -1.0/5.0},
                                    {0, -1.0/5.0, 0}};
    }

    private void GaussianInternal()
    {
      int GaussSize = Gaussian.GetLength(0);
      int ConvMatrixSide = GaussSize / 2;
      int StartX = BmpRect.Left + ConvMatrixSide;
      int StartY = BmpRect.Top + ConvMatrixSide;
      int EndX = BmpRect.Left + BmpRect.Width - ConvMatrixSide;
      int EndY = BmpRect.Top + BmpRect.Height - ConvMatrixSide;

      // Declare an array to hold the bytes of the bitmap.
      int bytes = bmpData.Stride * Bmp.Height;
      dstValues = new byte[bytes];
      dstValues = rgbValues;

      double G = 0.0;
      for (int Y = StartY; Y < EndY; Y++)
        for (int X = StartX; X < EndX; X++)
        {
          int ByteStart = Y * bmpData.Stride + X * BytesPerPixel;

          for (int p = 0; p < BytesPerPixel; p++)
          {
            int ByteLoc = ByteStart + p;
            for (int i = 0; i < GaussSize; i++)
              for (int j = 0; j < GaussSize; j++)
              {
                //int NeighByte = (Y-ConvMatrixSide+i)*bmpData.Stride + X*BytesPerPixel +
                //               p - ConvMatrixSide + j;
                int NeighByte = ByteLoc + bmpData.Stride * (i - ConvMatrixSide)
                                        + BytesPerPixel * (j - ConvMatrixSide);
                G += Gaussian[i, j] * rgbValues[NeighByte];
              }
            G = Math.Max(Math.Min(255, G), 0.0);
            dstValues[ByteLoc] = (byte)(G);
            G = 0;
          }
        }
    }

    public void ApplyGaussian()
    {
      if (!LockBitmap())
        return;

      GaussianInternal();

      UnlockBitmap(ref dstValues);
    }

    public void ConvertToGrayScale()
    {
      if (!LockBitmap())
        return;
      try
      {
        if (Bmp.PixelFormat == PixelFormat.Format24bppRgb || Bmp.PixelFormat == PixelFormat.Format32bppArgb)
        {
          for (int Y = 0; Y < Bmp.Height; Y++)
            for (int X = 0; X < Bmp.Width; X++)
            {
              int ByteStart = Y * bmpData.Stride + X * BytesPerPixel;
              byte blue = rgbValues[ByteStart];
              byte green = rgbValues[ByteStart + 1];
              byte red = rgbValues[ByteStart + 2];
              byte GrayVal = (byte)(.299 * red + .587 * green + .114 * blue);
              rgbValues[ByteStart] = rgbValues[ByteStart + 1] = rgbValues[ByteStart + 2] = GrayVal;
            }
        }
      }
      catch (Exception e)
      {

        MessageBox.Show(e.Message);
      }
      finally
      {
        UnlockBitmap(ref rgbValues);
      }
    }

    private void ApplyInternal()
    {
      int ConvMatrixSide = (int)FilterSize / 2;
      int StartX = BmpRect.Left + ConvMatrixSide;
      int StartY = BmpRect.Top + ConvMatrixSide;
      int EndX = BmpRect.Left + BmpRect.Width - ConvMatrixSide;
      int EndY = BmpRect.Top + BmpRect.Height - ConvMatrixSide;

      MaxGradient = double.NegativeInfinity;

      try
      {
        // Declare an array to hold the bytes of the bitmap.
        int bytes = bmpData.Stride * Bmp.Height;
        dstValues = new byte[bytes];

        if (mFilterType == FilterType.CannyFilter)
        {
          Gradients = new double[BmpRect.Width, BmpRect.Height, BytesPerPixel];
          Orientations = new byte[BmpRect.Width, BmpRect.Height, BytesPerPixel];
        }

        double G = 0.0, GradX = 0.0, GradY = 0, Orientation = 0;
        double Rad2Deg = 180.0 / System.Math.PI;

        for (int Y = StartY; Y < EndY; Y++)
          for (int X = StartX; X < EndX; X++)
          {
            int ByteStart = Y * bmpData.Stride + X * BytesPerPixel;

            for (int p = 0; p < BytesPerPixel; p++)
            {
              int ByteLoc = ByteStart + p;
              for (int i = 0; i < FilterSize; i++)
                for (int j = 0; j < FilterSize; j++)
                {
                  //int NeighByte = (Y-ConvMatrixSide+i)*bmpData.Stride + X*BytesPerPixel +
                  //               p - ConvMatrixSide + j;
                  int NeighByte = ByteLoc + bmpData.Stride * (i - ConvMatrixSide)
                                          + BytesPerPixel * (j - ConvMatrixSide);
                  GradX += ConvMatrix_Gx[i, j] * rgbValues[NeighByte];
                  GradY += ConvMatrix_Gy[i, j] * rgbValues[NeighByte];
                }
            
              if (mFilterType == FilterType.CannyFilter)
              {
                //G = Math.Min(255, Math.Abs(GradX) + Math.Abs(GradY));
                G = Math.Abs(GradX) + Math.Abs(GradY);
                Gradients[X, Y, p] = G;
                if (MaxGradient < Gradients[X, Y, p])
                  MaxGradient = Gradients[X, Y, p];
                if (GradX == 0)
                  Orientation = (GradY == 0) ? 0 : 90;
                else
                {
                  double GY_GX = GradY / GradX;
                  if (GY_GX < 0)  //2nd and 4th quads
                  {
                    Orientation = 180 - Math.Atan(-GY_GX) * Rad2Deg;
                  }
                  else  //1st and 3rd
                  {
                    Orientation = Math.Atan(GY_GX) * Rad2Deg;
                  }

                  // Get closest angle
                  if (Orientation < 22.5)
                    Orientation = 0;
                  else if (Orientation < 67.5)
                    Orientation = 45;
                  else if (Orientation < 112.5)
                    Orientation = 90;
                  else if (Orientation < 157.5)
                    Orientation = 135;
                  else Orientation = 0;
                }
                Orientations[X, Y, p] = (byte)(Orientation);
              }
              else
              {
                GradX = Math.Abs(GradX);
                GradY = Math.Abs(GradY);
                G = Math.Min(255, GradX + GradY);
                if (G > Threshold)
                {
                  //dstValues[ByteLoc] = rgbValues[ByteLoc];
                  dstValues[ByteLoc] = 0;// (byte)(255 - rgbValues[ByteLoc]);
                }
                else
                  //dstValues[ByteLoc] = 0;
                  dstValues[ByteLoc] = 255;
              }
              GradX = 0.0; GradY = 0.0;
            }

          }
      }
      catch (Exception)
      {
      }
    }

    private void SupressNonMaxima()
    {
      int ConvMatrixSide = (int)FilterSize / 2;
      int StartX = BmpRect.Left + ConvMatrixSide;
      int StartY = BmpRect.Top + ConvMatrixSide;
      int EndX = BmpRect.Left + BmpRect.Width - ConvMatrixSide;
      int EndY = BmpRect.Top + BmpRect.Height - ConvMatrixSide;

      double LeftPixel = 0, RightPixel = 0;
      for (int Y = StartY; Y < EndY; Y++)
        for (int X = StartX; X < EndX; X++)
        {
          int ByteStart = Y * bmpData.Stride + X * BytesPerPixel;

          for (int p = 0; p < BytesPerPixel; p++)
          {
            int ByteLoc = ByteStart + p;
            switch (Orientations[X, Y, p])  // Get adjacent pixels
            {
              case 0:
                LeftPixel = Gradients[X - 1, Y, p];
                RightPixel = Gradients[X + 1, Y, p];
                break;
              case 45:
                LeftPixel = Gradients[X - 1, Y + 1, p];
                RightPixel = Gradients[X + 1, Y - 1, p];
                break;
              case 90:
                LeftPixel = Gradients[X, Y + 1, p];
                RightPixel = Gradients[X, Y - 1, p];
                break;
              case 135:
                LeftPixel = Gradients[X + 1, Y + 1, p];
                RightPixel = Gradients[X - 1, Y - 1, p];
                break;

            }
            if (Gradients[X, Y, p] < LeftPixel || Gradients[X, Y, p] < RightPixel)
              dstValues[ByteLoc] = 0;
            else
              dstValues[ByteLoc] = (byte)((Gradients[X, Y, p] / MaxGradient) * 255);
              //dstValues[ByteLoc] = (byte)(Gradients[X, Y, p]);
          }
        }
    }

    public void ApplyFilter()
    {
      if (!LockBitmap())
        return;

      ApplyInternal();

      UnlockBitmap(ref dstValues);
    }
  }
}
