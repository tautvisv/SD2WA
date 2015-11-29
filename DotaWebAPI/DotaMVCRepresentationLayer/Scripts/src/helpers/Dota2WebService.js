var Globals = require("./Globals.js");
function responseNotFound(xhr, ajaxOptions, thrownError, callback){
    if(xhr.status==404) {
		if(typeof callback === "function") callback(null);
        alert(thrownError);
    }
};
var Dota2WebService = (function(){
	return {
		getAllHeroes: function(callback){
			$.ajax({
                url: Globals.WebApiUrl+Globals.DotaMisc+"AllHeroes",
                    success: function(response){
                    	if(typeof callback === "function") callback(response);
                    },
                    error:function(xhr, ajaxOptions, thrownError){
						responseNotFound(xhr, ajaxOptions, thrownError, callback)
					},
                });
		},
		getAllItems: function(callback){
			$.ajax({
                url: Globals.WebApiUrl+Globals.DotaMisc+"AllItems",
                    success: function(response){
                    	if(typeof callback === "function") callback(response);
                    },
                    error:responseNotFound,
                });
		},
		getWinrate: function(playerID, heroID, EnemyHeroId, refresh, callback){
			$.ajax({
                url: Globals.DotaUrl+"ChoosenWinrateAgainstHero/Player/"+playerID+"/Hero/"+heroID+"/EnemyHero/"+EnemyHeroId+ "/refresh/" + refresh,
                    success: function(response){
                    	console.log("from Service", JSON.stringify(response));
                    	if(typeof callback === "function") callback(response);
                    },
                    error:function(xhr, ajaxOptions, thrownError){
						responseNotFound(xhr, ajaxOptions, thrownError, callback)
					},
                });
		},
		getRating: function(playerID, matchCount, refresh, callback){
			if(!playerID){
				return;
			}
			$.ajax({
                url: Globals.DotaUrl+"PlayerRating/Player/"+playerID+"/"+(matchCount?"Count/"+matchCount+"/":"")+ "refresh/" + refresh,
                    success: function(response){
                    	console.log("from Service getRating", JSON.stringify(response));
                    	if(typeof callback === "function") callback(response);
                    },
                    error:function(xhr, ajaxOptions, thrownError){
						responseNotFound(xhr, ajaxOptions, thrownError, callback)
					},
                });
		},
		getVersus: function(playerID, heroID, functionName, matchCount, refresh, callback){
			console.log(playerID, heroID, functionName, matchCount, callback);
			if(!playerID){
				return;
			}
			var currentFunctionName;
			switch(functionName) {
			    case "best":
			    	currentFunctionName = "BestVinrateVersus"
			        break;
			    case "worst":
			        currentFunctionName = "WorstVs";
			        break;
			    default:
			        throw "function name: " + functionName + " not found";
			}
			$.ajax({
                url: Globals.DotaUrl+ currentFunctionName + "/Player/" + playerID + "/" +(matchCount?"Count/"+matchCount+"/":"") + "refresh/" + refresh,
                    success: function(response){
                    	console.log("from Service getVersus");
                    	console.log(response);
                    	if(typeof callback === "function") callback(response);
                    },
                    error:function(xhr, ajaxOptions, thrownError){
						responseNotFound(xhr, ajaxOptions, thrownError, callback)
					},
                });
		},
		getMatchInfo: function(matchID, callback){
			$.ajax({
                url: Globals.DotaUrl + "PlayerEfficiencyInMatch/Match/"+matchID,
                success: function(response){
                	console.log("from Service match info");
                	console.log(response);
                	if(typeof callback === "function") callback(response);
                },
                error:function(xhr, ajaxOptions, thrownError){
					responseNotFound(xhr, ajaxOptions, thrownError, callback)
				},
            });
		}
	};
})();

module.exports = Dota2WebService;