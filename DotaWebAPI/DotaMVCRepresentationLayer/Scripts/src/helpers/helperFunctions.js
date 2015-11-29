var Helper = (function(){
	var createRowItem = function(rowType){
		//TODO gaminti pagal tipą
	    return {
	        type: rowType,
	        heroId: "",
	        enemyHeroId: "",
	        matchCount: "",
	        gameState: "",
	    }
	}
	var validateInputOnlyNumbers = function(event){
         if(event.keyCode == 13){
            alert('Adding....');
         }
     }
	return {
		createRowItem:createRowItem,
		validateInputOnlyNumbers:validateInputOnlyNumbers
	}
})();

module.exports = Helper;