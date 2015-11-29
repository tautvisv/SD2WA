var React = require("react");
var HeroesSelect = require("./heroesSelectList.jsx");
var NumberInput = require("./NumberInput.jsx");
var SubmitButton = require("./SubmitButton.jsx");
var HeroesVsInformationItem = require("./HeroesVsInformationItem.jsx");
var Dota2WebService = require("./../helpers/Dota2WebService.js");

var HeroesVsItem = React.createClass({
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
        console.log("handleMatchCount", event.target.value);
        this.props.initState.matchCount = event.target.value;
        this.setState(this.props.initState);
    },
    handleGameStateChange: function(event) {
        console.log("handleGameStateChange", event.target.value);
        this.props.initState.gameState = event.target.value;
        this.setState(this.props.initState);
    },
    handleHeroChange: function(event){
        console.log("handleHeroChange", event.target.value);
        this.props.initState.heroId = event.target.value;
        this.setState(this.props.initState);
    },
    resetState: function(){
        console.log("resetting state state");
        console.log(this.state);
        var that = this;

        Dota2WebService.getVersus(this.state.playerId, this.state.heroId, this.state.gameState, this.state.matchCount, true, function(responseData){that.props.initState.response = responseData; that.setState(that.props.initState);});

    },
    render: function() {
        console.log("rendering content HeroesVsItem");
        return (<li>
            <div className="element-container">
                    <NumberInput 
                        onChangeFunction={this.handlePlayerIdChange} 
                        value={this.props.initState.playerId} 
                        placeholder="Player ID" />
                    <HeroesSelect 
                        heroValue={this.props.initState.heroId} 
                        handleHeroChangeFunction={this.handleHeroChange} />
                    <select 
                        value={this.props.initState.gameState} 
                        onChange={this.handleGameStateChange}  
                        className="content-list-select">
                        <option value="">function</option>
                        <option value="best">Best vs</option>
                        <option value="worst">Worst vs</option>
                    </select>
                    <NumberInput 
                        onChangeFunction={this.handleMatchCount} 
                        placeholder="Match count" 
                        value={this.props.initState.matchCount} />
                    <SubmitButton type="button" onClick={this.resetState} />
                    <HeroesVsInformationItem value={this.props.initState.response} reload={this.resetState} />
                    
                    <div className="boxclose" onClick={this.props.removeFuntion}></div>
                </div>
            </li>);
    }
}); 

module.exports = HeroesVsItem;