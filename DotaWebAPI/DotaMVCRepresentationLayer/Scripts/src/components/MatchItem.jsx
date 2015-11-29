var React = require("react");
var NumberInput = require("./NumberInput.jsx");
var SubmitButton = require("./SubmitButton.jsx");
var ServerIsBusyItem = require("./ServerIsBusyItem.jsx");
var Dota2WebService = require("./../helpers/Dota2WebService.js");
var Table = require("./DotaTable.jsx");

var TableTitle = React.createClass({
  render: function(){
    return (
      <div className="match-table-title">
        {this.props.value}
      </div>
    );
  }
});

var HeroImage =  React.createClass({
  render: function(){
    return (<img src={this.props.url} alt={this.props.HeroId} height="30" width="55"></img>);
  }
});

var MatchDetails =  React.createClass({
  render: function(){
    var radiantPlayers = this.props.data.players.slice(0,5);
    var direPlayers = this.props.data.players.slice(5,10);
    return (
      <div className="dota-information">
        <TableTitle value="Radiant"/>
        <Table data={radiantPlayers} />
        <TableTitle value="Dire"/>
        <Table data={direPlayers}/>
      </div>
    );
  }
});

var MatchInformationItem =  React.createClass({
  render: function(){
    if(this.props.value === null){
      return (<span className="error">Not found!!!</span>);
    }
    if(!this.props.value){
      return (<span>Press "Submit" button</span>)
    }
    if(this.props.value.WaitingTime){
      return (<ServerIsBusyItem value={this.props.value.WaitingTime} reload={this.props.reload} />)
    }
    if(this.props.value.Match){
      return (<MatchDetails data={this.props.value.Match} />);
    }
    return <span>Unexpected error</span>
  }
});

var MatchItem = React.createClass({
	 handleMatchId: function(event) {
        console.log("handleHeroChange", event.target.value);
        this.props.initState.matchId = event.target.value;
        this.setState(this.props.initState);
    },
    getInitialState: function() {
        return { items: this.props.initState };
    },
    resetState: function(){
        console.log("resetting state state");
        var that = this;
        Dota2WebService.getMatchInfo(this.props.initState.matchId, function(responseData){
          that.props.initState.response = responseData; 
          that.setState(that.props.initState);
          console.log(that.props.initState);
          console.log("state has changed");
        });
        //this.props.initState.response = responseData;
        //this.props.initState.playerId = responseData.PlayerId;
        //this.props.initState.heroId = responseData.HeroId;
        //this.props.initState.enemyHeroId = responseData.EnemyHeroId;
        //this.props.initState.matchCount = responseData.MatchCount;
        //this.props.initState.winrate = responseData.Winrate;
        //this.setState(this.props.initState);

        //this.setState(this.state);
    },
    render: function() {
        console.log("rendering content MatchItem");
        return (<li className={(this.props.initState.response && !this.props.initState.response.WaitingTime)?"big":""}>
            <div className="element-container">
                <NumberInput onChangeFunction={this.handleMatchId} placeholder="Match ID" value={this.props.initState.matchId} />
                <SubmitButton onClick={this.resetState} />
                <MatchInformationItem 
                  value={this.props.initState.response} 
                  reload={this.resetState} />
                <div className="boxclose" onClick={this.props.removeFuntion}></div>
            </div>
            </li>);
    }
}); 
module.exports = MatchItem;