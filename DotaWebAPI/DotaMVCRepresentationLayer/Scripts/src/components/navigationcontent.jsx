var React = require("react");
var ContentItem = require("./contentItem.jsx");
var AddContentItem = require("./AddContentItem.jsx");
var Helper = require("./../helpers/helperFunctions.js");
var AllHeroesSingleton = require("./../helpers/AllHeroesSingleton.js");
var ItemsSingleton = require("./../helpers/ItemsSingleton.js");


var Content = React.createClass({
    addEvent: function(tpeObject){
        console.log("addEvent");
        console.log(JSON.stringify(tpeObject));
        this.props.data.rows.unshift(Helper.createRowItem(tpeObject.type));
        this.setState(this.props.data);
    },
    removeItem: function(item){
        console.log("removeItem", JSON.stringify(item));
        console.log("removeItem", JSON.stringify(this.props.data));
        var index = this.props.data.rows.indexOf(item);
        console.log("removeItem", index);
        if(index >= 0) this.props.data.rows.splice(index, 1);
       // var items = this.props.data.rows.filter(function(itm){
        //    return item !== itm;
        //});
        this.setState(this.props.data);
    },
    render: function() {
        console.log("rendering navigation content");
        var allData = this.props.data;
        var that = this;

        var addItem = null;
        if(this.props.data && this.props.data.active) {
            AllHeroesSingleton.getInstance();
            ItemsSingleton.getInstance();
            addItem = <AddContentItem createFunction = { that.addEvent.bind(that, {type:allData.type}) } /> 
        }

        var items = this.props.data.rows.map(function(row, index) {
            console.log("Content adding row", JSON.stringify(row));
            return (
                <ContentItem key={"content_item_" + allData.type + "_" + index} 
                    data={row} onRemove={that.removeItem} 
                    addEventFunction={ that.addEvent.bind(that, {type:allData.type}) }/>
            );
        })


        return (
            <div className="content">
                <ul className="dota-info-list">
                    {addItem}
                    {items}
                </ul>
            </div>
        );
    }
});

module.exports = Content;

