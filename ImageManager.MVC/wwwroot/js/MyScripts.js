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

function inputFile_changed(files) {
	if (!files.length) {
		return;
	}

	var context = canvas.getContext("2d");
	var imgUrl = window.URL.createObjectURL(files[0])
	var img = new Image();

	img.onload = function () {
		canvas.width = this.width;
		canvas.height = this.height;
		canvas.title = "ширина: " + this.width + "; высота: " + this.height + "; " + files[0].size + " байт;";

		context.drawImage(img, 0, 0, this.width, this.height);
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
	canvas.style.filter = "grayscale(.8)";
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