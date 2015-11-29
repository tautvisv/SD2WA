var React = require("react");
var NavigationContent = require("./navigationcontent.jsx");
var NavigationBarItem = require("./navigationBarItem.jsx");


var NavigationBar = React.createClass({
	getInitialState: function() {
			console.log("init state");
		return {rows:[]}
	},
	handleClick: function(itemsData,arg1){
			var items = itemsData.tabs;
			var index = itemsData.index;
			items.map(function(item){
				item.active = false;
			});
			items[index].active = true;
			this.setState(items[index]);
	},
    render: function() {
    	var tabs = this.props.tabs;
    	var that = this;
    	console.log("rendering tabs");
        return (<div className="tabs-custom" >
				    <ul className="custom-nav clearfix" >
					    {
					    	this.props.tabs.map(function(tab, index) {
					    		tab.uniqueid = index+1;
					    		return <NavigationBarItem onClickEvent={that.handleClick.bind(that, {tabs:that.props.tabs, index:index})} tab={tab}  key={"manu_element_"+(index+1)}/>
				        })
				        }
				    </ul>
					<NavigationContent data={this.state} />
				</div>)
    }
});

module.exports = NavigationBar;
