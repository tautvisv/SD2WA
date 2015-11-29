var React = require("react");
var Timer = require("./Timer.jsx");

var ServerIsBusyItem = React.createClass({
    getInitialState: function() {
      return {time: this.props.value};
    },
    render: function() {
        return (<div><span>Server is busy, please wait for: </span>
        	<Timer val={this.props.value} 
            reload={this.props.reload} />
            <span>sec</span></div>)
    }
});

module.exports = ServerIsBusyItem;