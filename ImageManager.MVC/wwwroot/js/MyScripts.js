function inputFile_changed(files) {
	if (!files.length) {
		return;
	}

	var size = files[0].size + " байт;"

	var canvas = document.getElementById("myCanvas");
	var context = canvas.getContext("2d");

	var imgUrl = window.URL.createObjectURL(files[0])
	var img = new Image();
	img.onload = function () {
		canvas.width = this.width;
		canvas.height = this.height;

		context.drawImage(img, 0, 0, this.width, this.height);
		canvas.title = "ширина: " + this.width + "; высота: " + this.height + "; " + size;
	};

	var imageUrlInput = document.getElementById("imageUrl");
	imageUrlInput.value = imgUrl;

	img.src = imgUrl;
}


function open_click() {
	var fileInputItem = document.getElementById("fileInputItem");
	fileInputItem.click();
}
