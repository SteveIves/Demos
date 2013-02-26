/////////////////////////////////////////////////////////////
//
// CreateSilverlight.js
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////


// Standard createSilverlight implementation
function createSilverlight() {
    Silverlight.createObjectEx( {
        source:'Default.xaml',
        parentElement:document.getElementById('AgControl1Host'),
        id:'AgControl1',
        properties:{
            width:'100%',
            height:'100%',
            version:'1.1',
            isWindowless: 'True',
            background:'transparent'
        },
        events:{ onLoad:onLoad, onError:null },
        initParams:null,
        context:null
        } );
}


//
// Automatic Resize support
//

// Variables
var _silverlightControl;
var _originalWidth;
var _originalHeight;
var _rootScaleTransform;
var _rootTranslateTransform;

// Resizes the content to fit the container (preserving original aspect ratio)
function resize() {
    // Capture the current width/height
    var currentWidth = _silverlightControl.content.ActualWidth;
    var currentHeight = _silverlightControl.content.ActualHeight;

    if (_rootScaleTransform && _rootTranslateTransform && _originalWidth && _originalHeight) {
        // Scale the root Canvas to fit within the current control size
        var uniformScaleAmount = Math.min((currentWidth / _originalWidth), (currentHeight / _originalHeight));
        _rootScaleTransform.scaleX = uniformScaleAmount;
        _rootScaleTransform.scaleY = uniformScaleAmount;

        // Translate the root Canvas to center horizontally
        var scaledWidth = _originalWidth * uniformScaleAmount;
        _rootTranslateTransform.x = (currentWidth - scaledWidth) / 2;
        // var scaledHeight = _originalHeight * uniformScaleAmount;
        // _rootTranslateTransform.y = (currentHeight - scaledHeight) / 2;
    }
}

// Sets up the resize handler
function onLoad(control, userContext, sender) {
    // Capture the control
    _silverlightControl = control;

    // Find the root canvas
    var rootCanvas = sender.findName("rootCanvas");
    if (rootCanvas) {
        // Capture the original width/height
        _originalWidth = rootCanvas.width;
        _originalHeight = rootCanvas.height;

        // Create the necessary transforms on the root Canvas
        rootCanvas.renderTransform = _silverlightControl.content.createFromXaml('<TransformGroup><ScaleTransform Name="rootScaleTransform" ScaleX="1" ScaleY="1" /><TranslateTransform Name="rootTranslateTransform" X="0" Y="0" /></TransformGroup>');
        _rootScaleTransform = _silverlightControl.content.findName("rootScaleTransform");
        _rootTranslateTransform = _silverlightControl.content.findName("rootTranslateTransform");
    }

    // Hook up the resize handler
    _silverlightControl.content.onResize = resize;
    resize();
}
