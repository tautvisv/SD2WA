var React = require("react");
var ServerIsBusyItem = require("./ServerIsBusyItem.jsx");


var RatingInformationItem = React.createClass({

    render: function() {
        if(this.props.value === null){
          return (<span className="error">Not found!!!</span>);
        }
    	if(!this.props.value){
            return (<span>Press "Submit" button</span>)
        }

    	if(this.props.value.WaitingTime){
            return (<ServerIsBusyItem value={this.props.value.WaitingTime} reload={this.props.reload} />)
        }
        if(this.props.value.Rating){
	        return (
                <div className="dota-information">
                <span>PLayer&nbsp;{this.props.value.Rating.PlayerId}&nbsp;rating:&nbsp;</span>
                <span className="big">{this.props.value.Rating.Rating}&nbsp;MMR&nbsp;</span>
                <span>{"matches("+this.props.value.Rating.MatchCount+")"}</span>
                </div>
                );
                }
        return <span>Unexpected error</span>
    }
});

module.exports = RatingInformationItem;