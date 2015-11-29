var React = require("react");
var HeroInformation = require("./HeroInformation.jsx");
var ItemsSingleton = require("./../helpers/ItemsSingleton.js");

var TableTh = React.createClass({
  render: function(){
    return (<th className={this.props.position}>
      <acronym 
        data-placement="bottom" 
        data-toggle="tooltip" 
        title={this.props.title}>{this.props.text}
      </acronym>
      </th>);
  }
});
var TableHeader = React.createClass({
  render: function(){
    return (
      <thead>
        <tr>
        <th> </th>
          <TableTh text="Player ID" title="Uniq player ID"/>
          <TableTh position ="center" text="Hero" title="Hero name and icon"/>
          <TableTh text="Level" title="Hero Level"/>
          <TableTh text="K" title="Kills"/>
          <TableTh text="D" title="Deaths"/>
          <TableTh text="A" title="Assists"/>
          <TableTh text="KDA" title="KDA Ratio"/>
          <TableTh text="Gold" title="Total Gold Earned"/>
          <TableTh text="LH" title="Last Hits"/>
          <TableTh text="DN" title="Denies"/>
          <TableTh text="XPM" title="Experience earned per minute"/>
          <TableTh text="GPM" title="Gold earned per minute"/>
          <TableTh text="HD" title="Damage dealt to enemy Heroes"/>
          <TableTh text="HH" title="Healing provided to friendly Heroes"/>
          <TableTh text="TD" title="Damage dealt to enemy Towers"/>
          <TableTh text="Items" title="Items in inventory at the end of the Match"/>
        </tr>
      </thead>);
  }
});
var HeroItemElement = React.createClass({
  render: function(){
    var item = ItemsSingleton.getInstance().getItem(this.props.item);
    return (
      <div className="image-container"
          data-placement="bottom"
          data-toggle="tooltip" 
          title={item.localized_name}>
        <img className="image-icon" 
          src={"/Content/Icons/Items/"+item.imageName}
          width="33" 
          height="25">
        </img>
      </div>
      );
  }
});
var TableBodyRow = React.createClass({
  render: function(){
    var data = this.props.data;
    return (
      <tr className="faction-radiant"><td>
        </td>
        <td>{data.account_id}</td>
        <td className="r-none-mobile">
          <HeroInformation value={data.hero_id} height="20" width="37"/>
        </td>
        <td className="">{data.level}</td>
        <td className="">{data.kills}</td>
        <td className="">{data.deaths}</td>
        <td className="">{data.assists}</td>
        <td className="">{Math.round(((data.kills+data.assists)/data.deaths)*100)/100}</td>
        <td className="">{data.gold}</td>
        <td className="">{data.last_hits}</td>
        <td className="">{data.denies}</td>
        <td className="">{data.xp_per_min}</td>
        <td className="">{data.gold_per_min}</td>
        <td className="">{data.hero_damage}</td>
        <td className="">{data.hero_healing}</td>
        <td className="">{data.tower_damage}</td>
        <td className="">
          <HeroItemElement item={data.item_0}/>
          <HeroItemElement item={data.item_1}/>
          <HeroItemElement item={data.item_2}/>
          <HeroItemElement item={data.item_3}/>
          <HeroItemElement item={data.item_4}/>
          <HeroItemElement item={data.item_5}/>
        </td>
      </tr>
    );
    }
  });

var TableBody = React.createClass({
  render: function(){
    var playersInfo = this.props.players.map(function(player,index){
      return (
        <TableBodyRow key={"uniq_player_"+index} data={player}/>
      );
    });
    return (
      <tbody>
        {playersInfo}
      </tbody>
      );
  }
});
var TableFooter =  React.createClass({
  render: function(){
    var data = this.props.data;
      return (
      <tfoot>
        <tr>
          <td></td>
          <td></td>
          <td className=""></td>
          <td className="">{data.level}</td>
          <td className="">{data.kills}</td>
          <td className="">{data.deaths}</td>
          <td className="">{data.assists}</td>
          <td className="">{Math.round(((data.kills+data.assists)/data.deaths)*100)/100}</td>
          <td className="">{data.gold}</td>
          <td className="">{data.last_hits}</td>
          <td className="">{data.denies}</td>
          <td className="">{data.xp_per_min}</td>
          <td className="">{data.gold_per_min}</td>
          <td className="">{data.hero_damage}</td>
          <td className="">{data.hero_healing}</td>
          <td className="">{data.tower_damage}</td>
          <td className=""></td>
        </tr>
      </tfoot>
        );
    }
  });
var Table =  React.createClass({
  componentDidMount: function() {
    $('.match-table [data-toggle="tooltip"]').tooltip();
  },
  createFooterData: function(){
    var i;
    var obj = {
      level: 0,
      kills: 0,
      deaths: 0,
      assists: 0,
      gold: 0,
      last_hits: 0,
      denies: 0,
      xp_per_min: 0,
      gold_per_min: 0,
      hero_damage: 0,
      hero_healing: 0,
      tower_damage: 0,
    };
    var data = this.props.data;
    if(this.props.data)
      for(i = 0; i < this.props.data.length; i++){
          obj.level += data[i].level;
          obj.kills  += data[i].kills;
          obj.deaths  += data[i].deaths;
          obj.assists  += data[i].assists;
          obj.gold  += data[i].gold;
          obj.last_hits  += data[i].last_hits;
          obj.denies  += data[i].denies;
          obj.xp_per_min  += data[i].xp_per_min;
          obj.gold_per_min  += data[i].gold_per_min;
          obj.hero_damage  += data[i].hero_damage;
          obj.hero_healing  += data[i].hero_healing;
          obj.tower_damage  += data[i].tower_damage;
      }
    return obj;
  },
  render: function(){
    return (
      <table className="match-table">
      <TableHeader />
      <TableBody players={this.props.data} />
      <TableFooter data={this.createFooterData()}/>
      </table>

    );
  }
});

module.exports = Table;