using System;

namespace Hitachi_LG_LDS_Lidar {

  public class LidarSensorParser {

    public static readonly int PACKET_SIZE = 2520;

    public event EventHandler<string> OnWarning;

    public ARC.MessagingService.Navigation2DV1.ScanPoint[] ParseRawSensorPacket(byte[] data) {

      ARC.MessagingService.Navigation2DV1.ScanPoint [] scanPoints = new ARC.MessagingService.Navigation2DV1.ScanPoint[360];

      if (data.Length < PACKET_SIZE)
        throw new Exception(string.Format("Packet length ({0}) is less than required packet size", data.Length));
      else if (data.Length > PACKET_SIZE)
        throw new Exception(string.Format("Packet length ({0}) is greater than required packet size", data.Length));

      if (data[0] != 0xfa && data[1] != 0xa0)
        throw new Exception(string.Format("First data is not a packet header (expecting 0xfa, 0xa0 and received {0}, {1})", data[0], data[1]));

      for (int pos = 0; pos < data.Length; pos += 42) {

        // CRC Check
        if (data[pos] == 0xFA && data[pos + 1] != (0xA0 + pos / 42)) {

          OnWarning?.Invoke(this, "Packet failed CRC check");

          return new ARC.MessagingService.Navigation2DV1.ScanPoint[] { };
        }

        int rpm = (int)(int)BitConverter.ToUInt16(new byte[] { data[pos + 2], data[pos + 3] }, 0);

        int degree = (data[pos + 1] - 0xa0) * 6;

        if (degree < 0) {

          OnWarning?.Invoke(this, $"Invalid packet (degree reported {degree})");

          return new ARC.MessagingService.Navigation2DV1.ScanPoint[] { };
        }

        scanPoints[degree] = new ARC.MessagingService.Navigation2DV1.ScanPoint(
          (int)BitConverter.ToUInt16(new byte[] { data[pos + 6], data[pos + 7] }, 0) / 10,
          255,
          degree);

        scanPoints[degree + 1] = new ARC.MessagingService.Navigation2DV1.ScanPoint(
          (int)BitConverter.ToUInt16(new byte[] { data[pos + 12], data[pos + 13] }, 0) / 10,
          255,
          degree + 1);

        scanPoints[degree + 2] = new ARC.MessagingService.Navigation2DV1.ScanPoint(
          (int)BitConverter.ToUInt16(new byte[] { data[pos + 18], data[pos + 19] }, 0) / 10,
          255,
          degree + 2);

        scanPoints[degree + 3] = new ARC.MessagingService.Navigation2DV1.ScanPoint(
          (int)BitConverter.ToUInt16(new byte[] { data[pos + 24], data[pos + 25] }, 0) / 10,
          255,
          degree + 3);

        scanPoints[degree + 4] = new ARC.MessagingService.Navigation2DV1.ScanPoint(
          (int)BitConverter.ToUInt16(new byte[] { data[pos + 30], data[pos + 31] }, 0) / 10,
          255,
          degree + 4);

        scanPoints[degree + 5] = new ARC.MessagingService.Navigation2DV1.ScanPoint(
          (int)BitConverter.ToUInt16(new byte[] { data[pos + 36], data[pos + 37] }, 0) / 10,
          255,
          degree + 5);
      }

      return scanPoints;
    }
  }
}
