var React = require("react");
var Globals = require("./../helpers/Globals.js");
var HeroesSelect = require("./heroesSelectList.jsx");
var NumberInput = require("./NumberInput.jsx");
var SubmitButton = require("./SubmitButton.jsx");
var RatingInformationItem = require("./RatingInformationItem.jsx");
var Dota2WebService = require("./../helpers/Dota2WebService.js");

var RatingItem = React.createClass({
    getInitialState: function() {
        return this.props.initState;
    },
    handlePlayerIdChange: function(event){
        console.log("handlePlayerIdChange",event.target.value);
        console.log("handlePlayerIdChange", JSON.stringify(this.props.initState));
        console.log("handlePlayerIdChange", JSON.stringify(this.state));
        this.props.initState.playerId = event.target.value;
        this.setState(this.props.initState);
    },
    handleMatchCount: function(event) {
        console.log("handleHeroChange", event.target.value);
        this.props.initState.matchCount = event.target.value;
        this.setState(this.props.initState);
    },
    resetState: function(needToRefresh){
        console.log("resetting state state");
        var that = this;
        var needToRefreshP = typeof needToRefresh !== "undefined" && needToRefresh !== false? true : needToRefresh;
        Dota2WebService.getRating(this.state.playerId, this.state.matchCount, needToRefreshP, function(responseData){that.props.initState.response = responseData; that.setState(that.props.initState);});
        
    },
    render: function() {
        console.log("rendering content RatingItem");
        return (<li>
                <div className="element-container">
                    <NumberInput 
                        onChangeFunction={this.handlePlayerIdChange} 
                        value={this.props.initState.playerId} 
                        placeholder="Player ID" />
                    <span> </span>
                    <NumberInput 
                        onChangeFunction={this.handleMatchCount} 
                        placeholder="Match count" 
                        value={this.props.initState.matchCount} />
                    <SubmitButton onClick={this.resetState} />
                    <RatingInformationItem value={this.props.initState.response} reload={this.resetState} />
                    <div className="boxclose" onClick={this.props.removeFuntion}></div>
                </div>
            </li>);
    }
}); 

module.exports = RatingItem;