# FRT Project - Blazor Server Image Recognition App
DEMO - https://blazorimagerecognitionapp.azurewebsites.net/

## Azure Technologies used
 -Azure Services - Azure App Services, Azure Resource Manager 
 -Azure AI - Azure Computer Vision, Cognitive Search, Image Recognition
 
 ![azure](https://github.com/bhoomikamittal8/Future_Ready_Talent/assets/134505091/f7381171-9491-48c4-bbdf-0b3f3703e248)

## Description

Simple Blazor Server app which uses image recognition to identify and extract text printed in an image file uploaded by the user.  The app utilises the recognise printed text in image function in the Azure Computer Vision Cognitive service to identify and extract printed text from an uploaded image file

* GUI frontend project developed using Blazor Server/.Net 6
* Image printed text recognition engine is a class library project developed using .Net 6
   * Communicates with the Azure Computer Vision API v3.2
* Unit Test app which unit tests the image printed text recognition engine.  Uses MS Test .Net 6.

# Steps to Use with Screenshots
## Upload image file to analyse

![](BlazorServerImageRecognitionApp/wwwroot/images/UploadImageFile.png)

## Image file displayed and printed text from image displayed in text area

![](BlazorServerImageRecognitionApp/wwwroot/images/PrintedTextDisplayed.png)
