var React = require("react");

var Timer = React.createClass({
  getInitialState: function() {
    return {secondsElapsed: this.props.val, initTime: this.props.val, started: true};
  },
  tick: function() {
  	if(this.state.secondsElapsed < 1) {
    	this.setState({secondsElapsed: "Reloading...", started : false});
    	clearInterval(this.interval);
      this.props.reload(false);
    } else {
      console.log("changing timer to", this.props.val);
      var secondsElapsed = this.state.initTime === this.props.val ? this.state.secondsElapsed - 1: this.props.val;
    	this.setState({secondsElapsed: secondsElapsed, initTime: this.props.val, started: true });
	}
  	
  },
  componentDidMount: function() {
    this.interval = setInterval(this.tick, 1000);
  },
  componentWillUnmount: function() {
    clearInterval(this.interval);
  },
  render: function() {
    console.log("rendering timeer");
    if(!this.state.started &&  this.state.initTime !== this.props.val){
      clearInterval(this.interval);
      this.interval = setInterval(this.tick, 1000);
    }
    return (
            <span className="bigger">{this.state.secondsElapsed}</span>
    );
  }
});

module.exports = Timer;