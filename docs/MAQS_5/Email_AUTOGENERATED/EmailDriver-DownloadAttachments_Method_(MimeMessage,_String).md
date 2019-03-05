# EmailDriver.DownloadAttachments Method (MimeMessage, String)
 

Download all the attachments for the given message to a specific folder

**Namespace:**&nbsp;<a href="MAQS_5/Email_AUTOGENERATED/Magenic-Maqs-BaseEmailTest_Namespace">Magenic.Maqs.BaseEmailTest</a><br />**Assembly:**&nbsp;Magenic.Maqs.BaseEmailTest (in Magenic.Maqs.BaseEmailTest.dll) Version: 5.3.0

## Syntax

**C#**<br />
``` C#
public virtual List<string> DownloadAttachments(
	MimeMessage message,
	string downloadFolder
)
```


#### Parameters
&nbsp;<dl><dt>message</dt><dd>Type: MimeMessage<br />The email</dd><dt>downloadFolder</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The download folder</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(<a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>)<br />List of file paths for the downloaded files

## Examples

**C#**<br />
``` C#
[TestMethod]
[TestCategory(TestCategories.Email)]
public void DownloadAttachmentsToTestDefinedLocation()
{
    // Setup a test download location
    string downloadLocation = Path.Combine(EmailConfig.GetAttachmentDownloadDirectory(), Guid.NewGuid().ToString());
    string testFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestFiles");

    try
    {
        MimeMessage singleMessage = this.EmailDriver.GetMessage("Test/SubTest", "4");
        List<string> attchments = this.EmailDriver.DownloadAttachments(singleMessage, downloadLocation);

        Assert.AreEqual(3, attchments.Count, "Expected 3 attachments");

        foreach (string file in attchments)
        {
            string tempDownload = Path.Combine(downloadLocation, Guid.NewGuid().ToString());

            // Fix weird Git related CRLF issue
            if (file.EndsWith(".cs"))
            {
                string value = File.ReadAllText(Path.Combine(testFilePath, Path.GetFileName(file))).Replace("\r\n", "\n").Replace("\n", "\r\n");
                File.WriteAllText(tempDownload, value);

                value = File.ReadAllText(file).Replace("\r\n", "\n").Replace("\n", "\r\n");
                File.WriteAllText(file, value);
            }
            else
            {
                File.Copy(Path.Combine(testFilePath, Path.GetFileName(file)), tempDownload);
            }

            string downloadFileHash = this.GetFileHash(file);
            string testFileHash = this.GetFileHash(tempDownload);

            Assert.AreEqual(testFileHash, downloadFileHash, Path.GetFileName(file) + " test file and download file do not match");
        }
    }
    finally
    {
        Directory.Delete(downloadLocation, true);
    }
}
```


## See Also


#### Reference
<a href="MAQS_5/Email_AUTOGENERATED/EmailDriver_Class">EmailDriver Class</a><br /><a href="MAQS_5/Email_AUTOGENERATED/EmailDriver-DownloadAttachments_Method">DownloadAttachments Overload</a><br /><a href="MAQS_5/Email_AUTOGENERATED/Magenic-Maqs-BaseEmailTest_Namespace">Magenic.Maqs.BaseEmailTest Namespace</a><br />