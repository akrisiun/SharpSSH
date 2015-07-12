﻿using System.IO;
using Tamir.SharpSsh.java.io;

public class GenericSftpOutputStream : OutputStream
{
    Stream stream;
    public GenericSftpOutputStream(Stream stream)
    {
        this.stream = stream;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        stream.Write(buffer, offset, count);
    }

    public override void Flush()
    {
        stream.Flush();
    }

    public override void Close()
    {
        stream.Close();
    }

    public override bool CanSeek
    {
        get { return stream.CanSeek; }
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return stream.Seek(offset, origin);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (this.stream != null)
        {
            this.stream.Dispose();
            this.stream = null;
        }
    }
}