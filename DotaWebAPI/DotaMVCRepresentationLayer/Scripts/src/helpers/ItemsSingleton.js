var Globals = require("./Globals.js");
var Dota2WebService = require("./Dota2WebService.js");

var ItemsSingleton = (function () {
    var instance;
    
    function EmptyItem(){
        return {
            id: 0,
            name:"none",
            imageName:"none.png",
            cost:0,
            secret_shop:0,
            side_shop:0,
            recipe:0,
            localized_name:"Empty"
        };
    }

 	function CreateInstance(){
 		var obj = { Items: [] };
 		obj.getItem = function(id){
            var items;
            var i;
            if(!id){
                return EmptyItem();
            }
            items = obj.Items;
            for(i = 0; i < items.length; i++){
                if(items[i].id == id)
                    return items[i];
            }
 			return EmptyItem();
 		};
 		return obj;
 	}
    return {
        getInstance: function () {
            if (!instance) {
                instance = CreateInstance();
                console.log(Dota2WebService);
        		Dota2WebService.getAllItems(function(data) {
                    console.log("all Items here");
                    var items = data
                    instance.Items = items;
                    for(i = 0; i < items.length; i++){
                        if(items[i].recipe){
                            items[i].imageName = "recipe.png";
                        } else {
                            items[i].imageName = items[i].name.replace("item_", "").toLowerCase()+".png";
                        }
                    }
                    console.log(items);
                    console.log(instance.Items);
        		} );
            }
            return instance;
        }
    };
})();

module.exports = ItemsSingleton;