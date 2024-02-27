# FRT Project - Blazor Server Image Recognition and Text Extractor App
Project Demo URL - https://blazorimagerecognitionapp.azurewebsites.net/  
<br>
Project Demo Video URL- https://youtu.be/2DwIo8wiVQw?si=-1AbAoHfXTzud1Iz

## Azure Technologies used
 Azure Services - Azure App Services, Azure Resource Manager <br>
 Azure AI - Azure Computer Vision, Cognitive Search, Image Recognition
 
 ![azure](https://github.com/bhoomikamittal8/Future_Ready_Talent/assets/134505091/f7381171-9491-48c4-bbdf-0b3f3703e248)

## Description

Simple Blazor Server app which uses image recognition to identify and extract text printed in an image file uploaded by the user.  The app utilises the recognise printed text in image function in the Azure Computer Vision Cognitive service to identify and extract printed text from an uploaded image file

* GUI frontend project developed using Blazor Server/.Net 6
* Image printed text recognition engine is a class library project developed using .Net 6
   * Communicates with the Azure Computer Vision API v3.2
* Unit Test app which unit tests the image printed text recognition engine.  Uses MS Test .Net 6.
* Deployed Using Azure
# To Deploy
![Screenshot 2024-02-27 210943](https://github.com/bhoomikamittal8/Future_Ready_Talent/assets/134505091/e683d22f-076c-4f78-bd10-6b23a61c962d)
<br>
![Screenshot 2024-02-27 211018](https://github.com/bhoomikamittal8/Future_Ready_Talent/assets/134505091/d8645436-b3d8-4332-8473-a71d765d9752)
<br>
![Screenshot 2024-02-27 211027](https://github.com/bhoomikamittal8/Future_Ready_Talent/assets/134505091/36a45c0d-5e09-46f0-8cf3-fd7595539a3c)
<br>
![Screenshot 2024-02-27 211058](https://github.com/bhoomikamittal8/Future_Ready_Talent/assets/134505091/f6d2b707-1207-4157-a1fd-666700f04483)
<br>
![Screenshot 2024-02-27 211908](https://github.com/bhoomikamittal8/Future_Ready_Talent/assets/134505091/2842c001-9bcc-42b0-b676-96e83cc10dd7)


# Steps to Use with Screenshots
## Upload image file to analyse

![](BlazorServerImageRecognitionApp/wwwroot/images/UploadImageFile.png)

## Image file displayed and printed text from image displayed in text area

![](BlazorServerImageRecognitionApp/wwwroot/images/PrintedTextDisplayed.png)


