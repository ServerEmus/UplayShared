namespace UplayShared.Test;

public class Tests
{
    [Test]
    public void FormatLength()
    {
        uint max = uint.MinValue;
        uint len = Formatters.FormatLength(max);
        Assert.That(len, Is.EqualTo(max));
        max = uint.MaxValue;
        len = Formatters.FormatLength(max);
        Assert.That(len, Is.EqualTo(max));
        max = (uint)short.MaxValue;
        len = Formatters.FormatLength(max);
        Assert.That(len, Is.EqualTo(4286513152));
        max = (uint)byte.MaxValue;
        len = Formatters.FormatLength(max);
        Assert.That(len, Is.EqualTo(4278190080));
    }

    [Test]
    public void FormatUpstream()
    {
        byte[] data = [];
        byte[] newData = Formatters.FormatUpstream(data);
        Assert.That(newData, Is.EqualTo([0, 0, 0, 0]));

        data = [0xFF, 0xAA, 0xFF, 0xAA];
        newData = Formatters.FormatUpstream(data);
        Assert.That(newData, Is.EqualTo([0, 0, 0, 4, .. data]));
    }

    [Test]
    public void FormatFileSize()
    {
        ulong size = 0;
        string stringSize = Formatters.FormatFileSize(size);
        Assert.That(stringSize, Is.EqualTo("0.0 B"));
        stringSize = Formatters.FormatFileSize(size, 0);
        Assert.That(stringSize, Is.EqualTo("0 B"));
        stringSize = Formatters.FormatFileSize(size, 2);
        Assert.That(stringSize, Is.EqualTo("0.00 B"));

        size = ushort.MaxValue;
        stringSize = Formatters.FormatFileSize(size);
        Assert.That(stringSize, Is.EqualTo("64.0 KB"));
        stringSize = Formatters.FormatFileSize(size, 0);
        Assert.That(stringSize, Is.EqualTo("64 KB"));
        stringSize = Formatters.FormatFileSize(size, 2);
        Assert.That(stringSize, Is.EqualTo("64.00 KB"));

        size = int.MaxValue;
        stringSize = Formatters.FormatFileSize(size);
        Assert.That(stringSize, Is.EqualTo("2.0 GB"));
        stringSize = Formatters.FormatFileSize(size, 0);
        Assert.That(stringSize, Is.EqualTo("2 GB"));
        stringSize = Formatters.FormatFileSize(size, 2);
        Assert.That(stringSize, Is.EqualTo("2.00 GB"));

        size = int.MaxValue / 4;
        stringSize = Formatters.FormatFileSize(size);
        Assert.That(stringSize, Is.EqualTo("512.0 MB"));
        stringSize = Formatters.FormatFileSize(size, 0);
        Assert.That(stringSize, Is.EqualTo("512 MB"));
        stringSize = Formatters.FormatFileSize(size, 2);
        Assert.That(stringSize, Is.EqualTo("512.00 MB"));


        size = int.MaxValue / 3;
        stringSize = Formatters.FormatFileSize(size);
        Assert.That(stringSize, Is.EqualTo("682.7 MB"));
        stringSize = Formatters.FormatFileSize(size, 0);
        Assert.That(stringSize, Is.EqualTo("683 MB"));
        stringSize = Formatters.FormatFileSize(size, 2);
        Assert.That(stringSize, Is.EqualTo("682.67 MB"));


        size = ulong.MaxValue / ushort.MaxValue;
        stringSize = Formatters.FormatFileSize(size);
        Assert.That(stringSize, Is.EqualTo("256.0 TB"));
        stringSize = Formatters.FormatFileSize(size, 0);
        Assert.That(stringSize, Is.EqualTo("256 TB"));
        stringSize = Formatters.FormatFileSize(size, 2);
        Assert.That(stringSize, Is.EqualTo("256.00 TB"));

        size = ulong.MaxValue / 256;
        stringSize = Formatters.FormatFileSize(size);
        Assert.That(stringSize, Is.EqualTo("64.0 PB"));
        stringSize = Formatters.FormatFileSize(size, 0);
        Assert.That(stringSize, Is.EqualTo("64 PB"));
        stringSize = Formatters.FormatFileSize(size, 2);
        Assert.That(stringSize, Is.EqualTo("64.00 PB"));


        size = ulong.MaxValue;
        stringSize = Formatters.FormatFileSize(size);
        Assert.That(stringSize, Is.EqualTo("16.0 EB"));
        stringSize = Formatters.FormatFileSize(size, 0);
        Assert.That(stringSize, Is.EqualTo("16 EB"));
        stringSize = Formatters.FormatFileSize(size, 2);
        Assert.That(stringSize, Is.EqualTo("16.00 EB"));

        size = 345356234698;
        stringSize = Formatters.FormatFileSize(size);
        Assert.That(stringSize, Is.EqualTo("321.6 GB"));
        stringSize = Formatters.FormatFileSize(size, 0);
        Assert.That(stringSize, Is.EqualTo("322 GB"));
        stringSize = Formatters.FormatFileSize(size, 2);
        Assert.That(stringSize, Is.EqualTo("321.64 GB"));
        stringSize = Formatters.FormatFileSize(size, 6);
        Assert.That(stringSize, Is.EqualTo("321.638058 GB"));
    }

    [Test]
    public void FormatSliceHashChar()
    {
        Assert.That(Formatters.FormatSliceHashChar("aa"), Is.EqualTo('a'));
        Assert.That(Formatters.FormatSliceHashChar("ff"), Is.EqualTo('v'));
    }
}
