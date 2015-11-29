var React = require("react");

var NavigationBarItem = React.createClass({
	render: function() {
    	var tab = this.props.tab;
    	console.log("rendering tab");
        return <li onClick={this.props.onClickEvent} key={this.props.key} className={tab.active?"active":""} ><a href={"#"+tab.uniqueid}>{tab.title}</a></li>;
    }
});


module.exports = NavigationBarItem;