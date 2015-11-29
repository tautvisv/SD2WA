var React = require("react");

var SubmitButton = React.createClass({
    render: function() {
        return <button type="button" onClick={this.props.onClick} className="content-list-button">Submit</button>
    }
});

module.exports = SubmitButton;