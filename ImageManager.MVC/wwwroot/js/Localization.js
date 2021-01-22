var localizedStrings = {
	"en": {
		"width": "width",
		"heigth": "heigth",
		"originalSize": "original size",
		"bytes": "bytes",
		"somethingIsWrong": "Something is going wrong.",
		"maxValue": "maximum value",
		"rollBackTitle": "Roll back all changes.",
	},
	"ru": {
		"width": "ширина",
		"heigth": "высота",
		"originalSize": "изначальный размер",
		"bytes": "байт",
		"somethingIsWrong": "Что-то пошло не так.",
		"maxValue": "максимальное значение",
		"rollBackTitle": "Откатить все сделанные изменения.",
    }
}

function getLocale() {
	// .AspNetCore.Culture is a default asp cookie for culture, c%3Dru%7Cuic%3Dru is encoded 'c=ru|uic=ru'
	var ru = ".AspNetCore.Culture=c%3Dru%7Cuic%3Dru";
	if (document.cookie.includes(ru))
		return "ru";
	else
		return "en";
}