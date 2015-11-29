var React = require("react");

var AddContentItem = React.createClass({
    render: function() {
        console.log("rendering content add item");
        return (<li onClick={this.props.createFunction} className="add-item"><div id="cross"></div></li>);
    }
}); 

module.exports = AddContentItem;