using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace PDFUncompress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String getLine(Stream sr)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                int nData = sr.ReadByte();
                if (nData < 0)
                {
                    if (sb.Length == 0)
                        return null;
                    else
                        break;
                }

                if (nData == 0x0d)
                    continue;
                if (nData == 0x0a)
                    break;
                sb.Append((char)nData);
            }
            return sb.ToString();
        }

        private void btnUncompress_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
			if ( dlg.ShowDialog() != DialogResult.OK )
				return;

            using (FileStream sr = new FileStream(dlg.FileName, FileMode.Open))
			using (StreamWriter wr = new StreamWriter(dlg.FileName+".txt"))
            {
				var length_match = new Regex(@"Length (\d+)");
				var stream_match= new Regex("stream");
                var flate_match = new Regex("FlateDecode");
				int nLength = 0;
                int nCnt = 0;

				while(true) {

                    var line = getLine(sr);
                    if (line == null)
                        break;

                    if (nCnt > 0)
                        if (--nCnt == 0)
                            nLength = 0;

                    if (flate_match.IsMatch(line))
                    {
                        var matches = length_match.Match(line);
                        if (matches.Length > 0)
                        {
                            nLength = int.Parse(matches.Groups[1].Value);
                            nCnt = 2;
                        }
                    }

                    wr.WriteLine(line);

                    if (stream_match.IsMatch(line) && nLength > 0)
                    {

                        byte[] data = new byte[nLength];
                        sr.Read(data, 0, nLength);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            ms.Write(data, 0, nLength);
                            ms.Seek(2, SeekOrigin.Begin);

                            using (var deflate = new DeflateStream(ms, CompressionMode.Decompress))
                            {
                                wr.Flush();

                                while (true)
                                {
                                    int nReadByte = deflate.Read(data, 0, nLength);
                                    if (nReadByte == 0)
                                        break;
                                    wr.BaseStream.Write(data, 0, nReadByte);
                                }
                                wr.BaseStream.Flush();
                            }
                        }
                    }
                }
            }

            MessageBox.Show("解凍しました");
        }
    }
}
