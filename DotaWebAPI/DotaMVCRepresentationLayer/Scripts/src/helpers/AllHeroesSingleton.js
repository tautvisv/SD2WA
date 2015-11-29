var Dota2WebService = require("./Dota2WebService.js");

var AllHeroesSingleton = (function () {
    var instance;
 
 	function CreateInstance(){
 		var obj = { Heroes: [] };
 		obj.getHero = function(id){
 			return this.Heroes[id];
 		};
 		return obj;
 	}
    return {
        getInstance: function () {
            if (!instance) {
                instance = CreateInstance();
                console.log(Dota2WebService);
        		Dota2WebService.getAllHeroes(function(data) {
        			data.forEach(function(hero){ 
        				instance.Heroes[hero.id] = hero;
        				instance.Heroes[hero.id].imageName = hero.name.replace("npc_dota_hero_", "").toLowerCase();
        			});
        		} );
            }
            return instance;
        }
    };
})();

module.exports = AllHeroesSingleton;