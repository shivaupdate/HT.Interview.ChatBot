using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// TtsResponse
    /// </summary>
    public class TtsResponse : IDisposable
    {
        #region Private Fields

        private readonly byte[] _bytes;
        private readonly Stream _stream;

        #endregion

        #region Contructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stream"></param>
        public TtsResponse(Stream stream)
        {
            if (stream != null && stream.Length > 0)
            {
                _stream = stream;
                _bytes = ReadFully(stream);
            }

        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Bytes
        /// </summary>
        public byte[] Bytes { get { return _bytes; } }

        /// <summary>
        /// Stream
        /// </summary>
        public Stream Stream { get { return _stream; } }

        #endregion

        #region Private Methods

        /// <summary>
        /// Read fully
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private byte[] ReadFully(Stream stream)
        {
            byte[] buffer = new byte[stream.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Create a file
        /// </summary>
        /// <param name="path">Path not include filne name.</param>
        /// <returns>File name</returns>
        public async Task<string> WriteToFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }

                if (_bytes != null && _bytes.Count() > 0)
                {
                    var fileName = $"{Guid.NewGuid().ToString()}.wav";

                    using (FileStream fileStream = new FileStream($"{path}\\{fileName}", FileMode.Create))
                    {
                        await fileStream.WriteAsync(_bytes, 0, _bytes.Length);
                        return fileName;
                    }
                }
                else
                {
                    throw new Exception("Write to file error - Byte array is empty.");
                }
            }
            else
            {
                throw new Exception("Write to file error - Path is null or empty.");
            }

        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (_stream != null)
            {
                _stream.Close();
            }

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
