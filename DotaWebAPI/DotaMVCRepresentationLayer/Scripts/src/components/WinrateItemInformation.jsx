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
        if(that.props.value.HeroId) {
            heroItem = (
                <div className="display-inline">
                <span >&nbsp; with hero: </span>
                <HeroInformation value={that.props.value.EnemyHeroId}/>
                </div>
                );
        }
        var enemyHeroItem = null;
        if(that.props.value.EnemyHeroId) {
            enemyHeroItem = (
                <div className="display-inline">
                <span>&nbsp; against: </span>
                <HeroInformation value={that.props.value.EnemyHeroId}/>
                </div>);
        }
        if (this.props.value.Winrate) {
            return  (
                <div className="dota-information"><span>PLayer {this.props.value.PlayerId} winrate </span>
	            {heroItem}
                {enemyHeroItem}
                <span> is: </span>
                <span className="big">{this.props.value.Winrate}% </span>
                </div>
                );
        }


        return <span>Unexpected error</span>
    }
});

module.exports = WinrateItemInformation;