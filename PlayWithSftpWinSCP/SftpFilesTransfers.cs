using System;
using WinSCP;

namespace PlayWithSftpWinSCP
{
    class SftpFilesTransfers
    {
        public void Transfer()
        {
            try
            {
                var sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = "192.168.50.246",
                    UserName = "user",
                    Password = "password",
                    PortNumber = 22,
                    SshHostKeyFingerprint = "ssh-rsa 2048 VSl9gWbLBuU/gnMvbw6ylJv17B6eUBB4jS942zKd6Hs="
                };

                using (var session = new Session())
                {
                    session.Open(sessionOptions);

                    var transferOptions = new TransferOptions
                    {
                        TransferMode = TransferMode.Binary
                    };

                    TransferOperationResult transferResult;

                    // Upload
                    //transferResult =
                    //    session.PutFiles(@"D:\sqid\SFTPFiles\uploads", @"\public\", false, transferOptions);

                    // Download
                    transferResult =
                        session.GetFiles(@"\public\", @"D:\sqid\SFTPFiles\downloads", false, transferOptions);

                    // Throw on any error
                    transferResult.Check();

                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex);
            }
        }
    }
}
