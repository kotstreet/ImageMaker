var canvas = document.getElementById("myCanvas");
var imageUrlInput = document.getElementById("imageUrl");
var fileInputItem = document.getElementById("fileInputItem");

var blurFilterButton = document.getElementById("blurFilter");
var brightnessFilterButton = document.getElementById("brightnessFilter");
var notBrightnessFilterButton = document.getElementById("notBrightnessFilter");
var contrastFilterButton = document.getElementById("contrastFilter");
var shadowFilterButton = document.getElementById("shadowFilter");
var grayscaleFilterButton = document.getElementById("grayscaleFilter");

var hueRotate1FilterButton = document.getElementById("hueRotate1Filter");
var hueRotate2FilterButton = document.getElementById("hueRotate2Filter");
var hueRotate3FilterButton = document.getElementById("hueRotate3Filter");
var invertFilterButton = document.getElementById("invertFilter");
var sepiaFilterButton = document.getElementById("sepiaFilter");
var noneFilterButton = document.getElementById("noneFilter");

var filters = [
	blurFilterButton,
	brightnessFilterButton,
	notBrightnessFilterButton,
	contrastFilterButton,
	shadowFilterButton,
	grayscaleFilterButton,

	hueRotate1FilterButton,
	hueRotate2FilterButton,
	hueRotate3FilterButton,
	invertFilterButton,
	sepiaFilterButton,
	noneFilterButton,
]

var angle = 0;
var size = 0;

function calcAngle(incAngle) {
	angle = angle + incAngle;
	if (angle < 0) {
		angle = angle + 360;
	}
	if (angle >= 360) {
		angle = angle - 360;
	}
}

function calcCanvasWidth(width) {
	if (width > 900) {
		canvas.width = width;
	}
	else {
		canvas.width = 900;
	}
}

function calcCanvasHeight(height) {
	if (height > 550) {
		canvas.height = height;
	}
	else {
		canvas.height = 550;
	}
}

function setCanvasTitle(width, height) {
	canvas.title = "ширина: " + width + "; высота: " + height + "; " + size + " байт;";
}

function settingCanvasByAngle(context, img) {
	switch (angle) {
		case 90:
			calcCanvasWidth(img.height);
			calcCanvasHeight(img.width);
			setCanvasTitle(img.height, this.width);
			context.translate(img.height, 0);
			break;
		case 180:
			calcCanvasWidth(img.width);
			calcCanvasHeight(img.height);
			setCanvasTitle(img.width, img.height);
			context.translate(img.width, img.height);
			break;
		case 270:
			calcCanvasWidth(img.height);
			calcCanvasHeight(img.width);
			setCanvasTitle(img.height, img.width);
			context.translate(0, img.width);
			break;
		default:
			calcCanvasWidth(img.width);
			calcCanvasHeight(img.height);
			setCanvasTitle(img.width, img.height);
	}
}

function rotateLeft_click() {
	var context = canvas.getContext("2d");
	var imgUrl = imageUrlInput.value;
	var img = new Image();

	img.onload = function () {
		context.save();
		context.clearRect(0, 0, canvas.width, canvas.height);

		calcAngle(-90);
		settingCanvasByAngle(context, this);		

		context.rotate(angle * Math.PI / 180);
		context.drawImage(img, 0, 0);
		context.restore();
	};
	img.src = imgUrl;
}

function rotateRight_click() {
	var context = canvas.getContext("2d");
	var imgUrl = imageUrlInput.value;
	var img = new Image();

	img.onload = function () {
		context.save();
		context.clearRect(0, 0, canvas.width, canvas.height); 

		calcAngle(90);
		settingCanvasByAngle(context, this);

		context.rotate(angle * Math.PI / 180); 
		context.drawImage(img, 0, 0); 
		context.restore();
	};
	img.src = imgUrl;
}

function inputFile_changed(files) {
	if (!files.length) {
		return;
	}

	var context = canvas.getContext("2d");
	var imgUrl = window.URL.createObjectURL(files[0])
	var img = new Image();

	img.onload = function () {
		calcCanvasWidth(this.width);
		calcCanvasHeight(this.height);

		size = files[0].size;
		setCanvasTitle(this.width, this.height);

		context.drawImage(img, 0, 0);
	};

	imageUrlInput.value = imgUrl;
	img.src = imgUrl;
	noneFilterButton.click();
}

function open_click() {
	fileInputItem.click();
}

function someFiterClick(button) {
	for (var i = 0; i < filters.length; i++) {
		filters[i].style.fontWeight = "400";
		filters[i].style.backgroundColor = "#d4fff8";
	}

	button.style.fontWeight = "600";
	button.style.backgroundColor = "#a1ffca";
}


function noneFiltrButton_click() {
	canvas.style.filter = "none";
	someFiterClick(noneFilterButton);
}

function blurFiltrButton_click() {
	canvas.style.filter = "blur(3px)";
	someFiterClick(blurFilterButton);
}

function brightnessFiltrButton_click() {
	canvas.style.filter = "brightness(150%)";
	someFiterClick(brightnessFilterButton);
}

function notBrightnessFiltrButton_click() {
	canvas.style.filter = "brightness(50%)";
	someFiterClick(notBrightnessFilterButton);
}

function contrastFiltrButton_click() {
	canvas.style.filter = "contrast(25%)";
	someFiterClick(contrastFilterButton);
}

function shadowFiltrButton_click() {
	canvas.style.filter = "drop-shadow(0 0 3px rgba(100,0,0,0.5))";
	someFiterClick(shadowFilterButton);
}

function grayscaleButton_click() {
	canvas.style.filter = "grayscale(1)";
	someFiterClick(grayscaleFilterButton);
}

function invertButton_click() {
	canvas.style.filter = "invert(100%)";
	someFiterClick(invertFilterButton);
}

function hueRotate1Button_click() {
	canvas.style.filter = "hue-rotate(90deg)";
	someFiterClick(hueRotate1FilterButton);
}

function hueRotate2Button_click() {
	canvas.style.filter = "hue-rotate(180deg)";
	someFiterClick(hueRotate2FilterButton);
}

function hueRotate3Button_click() {
	canvas.style.filter = "hue-rotate(270deg)";
	someFiterClick(hueRotate3FilterButton);
}

function sepiaFiltrButton_click() {
	canvas.style.filter = "sepia(75%)";
	someFiterClick(sepiaFilterButton);
}