var React = require("react");
var ServerIsBusyItem = require("./ServerIsBusyItem.jsx");
var AllHeroesSingleton = require("./../helpers/AllHeroesSingleton.js");

var HeroWinrateInformation = React.createClass({

    render: function() {
        var hero = AllHeroesSingleton.getInstance().getHero(this.props.value.HeroId);
        console.log(hero);
        if(!hero) return (<div>No Hero</div>)
    	return (<div className="display-inline">
    		<img src={"\\Content\\Icons\\Heroes\\"+hero.imageName+"_full.png"} alt={hero.localized_name} height="30" width="55"></img>
    		<span >&nbsp;{hero.localized_name + "-" + this.props.value.Winrate}%&nbsp;</span>
    		</div>);
    }
});

var HeroesVsInformationItem = React.createClass({

    render: function() {
        if(this.props.value === null){
          return (<span className="error">Not found!!!</span>);
        }
    	if(!this.props.value){
            return (<span>Press "Submit" button</span>)
        }
        if(this.props.value.WaitingTime){
            return (<ServerIsBusyItem value={this.props.value.WaitingTime} reload={this.props.reload}/>)
        }
        
		if(this.props.value.Information){

            var heroesData = this.props.value.Information.HeroesWinrates.map(function(winrate, index) {
                return <HeroWinrateInformation key={"hero_winrate_"+index} value={winrate} />
            })

	        return (
                <div className="dota-information">
                <span>PLayer&nbsp;</span>
                <span>{this.props.value.Information.PlayerId}&nbsp;</span>
                {heroesData}
	            </div>
                );
        }
        
        return <span>Unexpected error</span>
    }
});

module.exports = HeroesVsInformationItem;