var React = require("react");
var HeroInformation = require("./HeroInformation.jsx");
var ServerIsBusyItem = require("./ServerIsBusyItem.jsx");

var WinrateItemInformation = React.createClass({
    render: function() {
        console.log("WinrateItemInformation", JSON.stringify(this.props.value));
        if(this.props.value === null){
          return (<span className="error">Not found!!!</span>);
        }
        if(!this.props.value){
            return (<span>Press "Submit" button</span>);
        }
        if(this.props.value.WaitingTime){
            return (<ServerIsBusyItem value={this.props.value.WaitingTime} reload={this.props.reload} />);
        }
        var that = this;
        var heroItem = null;
        var winrateData = that.props.value.Winrate;
        
        if (winrateData) {
            if(winrateData.HeroId) {
            heroItem = (
                <div className="display-inline">
                <span >&nbsp; with hero: </span>
                <HeroInformation value={winrateData.HeroId}/>
                </div>
                );
        }
        var enemyHeroItem = null;
        if(winrateData.EnemyHeroId) {
            enemyHeroItem = (
                <div className="display-inline">
                <span>&nbsp; against: </span>
                <HeroInformation value={winrateData.EnemyHeroId}/>
                </div>);
        }

            return  (
                <div className="dota-information"><span>PLayer {winrateData.PlayerId} winrate </span>
	            {heroItem}
                {enemyHeroItem}
                <span> is: </span>
                <span className="big">{winrateData.Winrate}% </span>
                </div>
                );
        }


        return <span>Unexpected error</span>
    }
});

module.exports = WinrateItemInformation;