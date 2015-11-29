var React = require("react");
var AllHeroesSingleton = require("./../helpers/AllHeroesSingleton.js");

var HeroInformation = React.createClass({
    render: function() {
		var hero = AllHeroesSingleton.getInstance().getHero(this.props.value);
        var height = this.props.height?this.props.height:30;
        var width = this.props.width?this.props.width:55;
        return (
            <div className="display-inline" >
                <img 
                    src={"\\Content\\Icons\\Heroes\\" + hero.imageName + "_full.png"}
                    alt={hero.localized_name}
                    height={height}
                    width={width}>
                </img>
                <span>&nbsp;{hero.localized_name}</span>
            </div>
        );
    }
});

module.exports = HeroInformation;