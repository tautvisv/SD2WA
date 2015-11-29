var React = require("react");
var ReactDome = require("react-dom");

var PageNavigation = require("./components/pagenavigation.jsx");
var selectList = ["active","","",""];
var tabs = [	{ title: "Match analysis", active: false, rows:[], type:1 },
	{ title: "Winrate", active: false,  rows:[], type:2 },
	{ title: "Rating", active: false,  rows:[], type:3 },
	{ title: "Heroes vs", active: false,  rows:[], type:4 }];
ReactDome.render(<PageNavigation tabs={tabs}/>, document.getElementById("app"));


//Kodėl neveikia prototype
//Kaip parefreshint kai atsinaujino