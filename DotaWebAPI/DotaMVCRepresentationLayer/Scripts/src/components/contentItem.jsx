var React = require("react");
var MatchItem = require("./MatchItem.jsx");
var AddContentItem = require("./AddContentItem.jsx");
var WinrateItem = require("./WinrateItem.jsx");
var HeroesVsItem = require("./HeroesVsItem.jsx");
var RatingItem = require("./RatingItem.jsx");

var ContentItem = React.createClass({
    createFuntion: function(tpeObject){
        this.props.addEventFunction(tpeObject);
    },
    removeFunction: function(){
        this.props.onRemove(this.props.data);
    },
    render: function() {
                        console.log("ContentItem adding row", this.props.data);
        var item = this.props.data;
        var that = this;
        switch(item.type) {
            case 0:
                return (<AddContentItem createFunction={this.createFuntion} />)
            case 1:
                return (<MatchItem initState={this.props.data} removeFuntion={this.removeFunction}/>)
            case 2:
                return (<WinrateItem initState={this.props.data} removeFuntion={this.removeFunction}/>)
            case 3:
                return (<RatingItem initState={this.props.data} removeFuntion={this.removeFunction}/>)
            case 4:
                return (<HeroesVsItem initState={this.props.data} removeFuntion={this.removeFunction}/>)
            default:
                return (<AddContentItem createFunction={this.createFuntion} />)
        }
    }
});

module.exports = ContentItem;