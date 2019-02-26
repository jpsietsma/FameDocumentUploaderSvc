# FAME - Windows Service - Document Uploader


- Service runs and monitors the upload directory
- Creates the appropriate log files as expected
- Does all validation of the document type and the farm ID
- Files dropped are then logged to the SQL table successfully!
- Sends email notifications on duplicate file drops if the type does not allow it
- Handles document revisions

Still need to:
- Do permissions checking on user to ensure appropriate ability
- Add in daily/hourly (whichever) Upload Report email feature
- Determine user that uploaded file
