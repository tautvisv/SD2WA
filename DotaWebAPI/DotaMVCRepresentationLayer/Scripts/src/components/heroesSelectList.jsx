var React = require("react");

var AllHeroesSingleton = require("./../helpers/AllHeroesSingleton.js");

var HeroesSelectList = React.createClass({
    getInitialState: function() {
        return AllHeroesSingleton.getInstance();
    },
    getAllHeroes: function(){
        return AllHeroesSingleton.getInstance().Heroes;
    },
    setCustomState: function(){
        this.setState({});
    },
    render: function() {
        console.log("rendering HeroList");
        return <select value={this.props.heroValue} onChange={this.props.handleHeroChangeFunction} className="content-list-select ">
                    <option value="">Hero select</option>
                    {
                        AllHeroesSingleton.getInstance().Heroes.map(function(hero, index) {
                            return <option key={index} value={hero.id}>{hero.localized_name}</option>
                        })
                    }
                </select>
    }
});


module.exports = HeroesSelectList;