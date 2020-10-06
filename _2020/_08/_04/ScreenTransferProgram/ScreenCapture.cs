using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ScreenTransferProgram
{
    class ScreenCapture
    {
        public const long SCREEN_CAPTURE_QUALITY = 50L;         // 화면 캡처 이미지의 화질
        public const int REDUCED_IMAGE_WIDTH = 565;             // 축소된 이미지의 너비
        public const int REDUCED_IMAGE_HEIGHT = 430;            // 축소된 이미지의 높이

        int mScreenWidth = 0;                                   // 화면의 너비
        int mScreenHeight = 0;                                  // 화면의 높이
        String mBaseDir = "";
        byte[] mImageArray = null;                          // image 배열

        /// <summary>
        /// 생성자
        /// </summary>
        public ScreenCapture()
        {
            init();
        }

        /// <summary>
        /// 클래스 초기화 메소드
        /// </summary>
        private void init()
        {
            mScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            mScreenHeight = Screen.PrimaryScreen.Bounds.Height;

            mBaseDir = AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// 캡쳐한 화면 이미지를 byte 배열로 반환
        /// </summary>
        /// <returns>캡쳐한 화면 이미지의 byte 배열</returns>
        public byte[] GetScreenImageByteArray()
        {
            mImageArray = null;

            Bitmap screenImage = GetScreenCaptureImage();           // 캡쳐한 화면의 이미지를 얻음
            Bitmap reducedImage = GetReducedImage(screenImage);     // 캡쳐한 이미지를 축소

            mImageArray = GetByteArrayFromImage(reducedImage);      // 이미지를 byte 배열로 변환

            return mImageArray;
        }

        /// <summary>
        /// byte 배열에 저장되어 있는 이미지를 bitmap 객체로 반환
        /// </summary>
        /// <param name="imageArray">이미지가 저장되어 있는 byte 배열</param>
        /// <param name="arraySize">byte 배열의 크기</param>
        /// <returns></returns>
        public Bitmap GetScreenImage(byte[] imageArray, int arraySize)
        {
            Bitmap screenImage = null;

            screenImage = GetBitmapFromByteArray(imageArray, arraySize);

            return screenImage;
        }

        /// <summary>
        /// 현재 화면을 캡쳐
        /// </summary>
        /// <returns>캡쳐된 화면 이미지</returns>
        private Bitmap GetScreenCaptureImage()
        {
            Bitmap bitmap = new Bitmap(mScreenWidth, mScreenHeight);

            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(0, 0, 0, 0, new Size(mScreenWidth, mScreenHeight));

            return bitmap;
        }

        /// <summary>
        /// 이미지를 축소하는 함수
        /// </summary>
        /// <param name="screenImage">축소할 이미지</param>
        /// <returns>축소된 이미지</returns>
        private Bitmap GetReducedImage(Bitmap screenImage)
        {
            Bitmap reducedImage = null;

            reducedImage = new Bitmap(screenImage, REDUCED_IMAGE_WIDTH, REDUCED_IMAGE_HEIGHT);

            return reducedImage;
        }

        /// <summary>
        /// Bitmap 객체로 되어 있는 이미지를 byte 배열 형태로 변환
        /// </summary>
        /// <param name="bitmap">Bitmap 객체로 되어 있는 이미지</param>
        /// <returns>byte 배열로 변환된 이미지</returns>
        private byte[] GetByteArrayFromImage(Bitmap bitmap)
        {
            try
            {
                // Memory Stream
                MemoryStream ms = new MemoryStream();

                // Jpeg Encoding
                ImageCodecInfo myImageCodecInfo;
                System.Drawing.Imaging.Encoder myEncoder;
                EncoderParameter myEncoderParameter;
                EncoderParameters myEncoderParameters;

                myImageCodecInfo = GetEncoderInfo("image/jpeg");
                myEncoder = System.Drawing.Imaging.Encoder.Quality;

                myEncoderParameters = new EncoderParameters(1);
                myEncoderParameter = new EncoderParameter(myEncoder, SCREEN_CAPTURE_QUALITY);  // 압축률 지정
                myEncoderParameters.Param[0] = myEncoderParameter;
                bitmap.Save(ms, myImageCodecInfo, myEncoderParameters);

                return ms.ToArray();
            }
            catch
            {
                ;
            }
            return null;
        }

        /// <summary>
        /// 인코더 정보를 구해오는 함수
        /// </summary>
        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        /// <summary>
        /// byte 배열에 저장되어 있는 이미지를 bitmap 객체로 변환
        /// </summary>
        /// <param name="imageArray">이미지가 저장되어 있는 byte 배열</param>
        /// <param name="arraySize">byte 배열의 크기</param>
        /// <returns>bitmap 객체로 변환된 이미지</returns>
        private Bitmap GetBitmapFromByteArray(byte[] imageArray, int arraySize)
        {
            try
            {
                MemoryStream ms = new MemoryStream(arraySize);
                ms.Write(imageArray, 0, arraySize);
                ms.Seek(0, SeekOrigin.Begin);

                Bitmap image = new Bitmap(ms);
                return image;
            }
            catch
            {
                ;
            }
            return null;
        }
    }
}
