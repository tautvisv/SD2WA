var React = require("react");
var HeroesSelect = require("./heroesSelectList.jsx");
var NumberInput = require("./NumberInput.jsx");
var SubmitButton = require("./SubmitButton.jsx");
var WinrateItemInformation = require("./WinrateItemInformation.jsx");
var Dota2WebService = require("./../helpers/Dota2WebService.js");


var WinrateItem = React.createClass({
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
    handleHeroChange: function(event) {
    	console.log("handleHeroChange", event.target.value);
	    this.props.initState.heroId = event.target.value;
	    this.setState(this.props.initState);
	},
	handleEnemyHeroChange: function(event) {
    	console.log("handleHeroChange", event.target.value);
	    this.props.initState.enemyHeroId = event.target.value;
	    this.setState(this.props.initState);
	},
	handleMatchCount: function(event) {
    	console.log("handleHeroChange", event.target.value);
	    this.props.initState.matchCount = event.target.value;
	    this.setState(this.props.initState);
	},
    resetState: function(){
    	console.log("resetting state winrate",this.state);
        var that = this;
        Dota2WebService.getWinrate(this.state.playerId, this.state.heroId, this.state.enemyHeroId, this.state.matchCount, true, 
            function(responseData){
                that.props.initState.response = responseData;
                that.setState(that.props.initState);
             });
    },
    
    render: function() {
        console.log("rendering content WinrateItem");
        var valueheroIdLink = {
	      value: this.props.initState.playerId,
	      requestChange: this.handleHeroChange
	    };
                        console.log("WinrateItem adding row", JSON.stringify(this.props.initState));
        return (<li>
                <div className="element-container">
                    <NumberInput 
                        onChangeFunction={this.handlePlayerIdChange}  
                        value={this.props.initState.playerId} 
                        placeholder="Player ID" />
                    <HeroesSelect 
                        heroValue={this.props.initState.heroId} 
                        handleHeroChangeFunction={this.handleHeroChange} />
                    <HeroesSelect 
                        heroValue={this.props.initState.enemyHeroId} 
                        handleHeroChangeFunction={this.handleEnemyHeroChange} />
                    <NumberInput 
                        onChangeFunction={this.handleMatchCount} 
                        placeholder="Match count" 
                        value={this.props.initState.matchCount} />
                    <SubmitButton type="button" onClick={this.resetState} />
                    <WinrateItemInformation 
                        value={this.props.initState.response}
                        reload={this.resetState} />
                    <div className="boxclose" onClick={this.props.removeFuntion}></div>
                </div>
                </li>)
    }
}); 
module.exports = WinrateItem;