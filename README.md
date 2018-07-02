# FameDocumentUploaderSvc


- Service runs and monitors the upload directory
- Creates the appropriate log files as expected
- Does all validation of the document type and the farm ID
- Determines user who uploaded file from Windows Security event logs
- Files dropped are then logged to the SQL table successfully!

Still need to:
- Get file uploader from security logs
- Do permissions checking on user to ensure appropriate ability
- Add in daily/hourly (whichever) Upload Report email feature
