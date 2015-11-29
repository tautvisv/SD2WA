var React = require("react");

var NumberInput = React.createClass({
	numberValidation: function(event){
        var keyCode = event.keyCode;
        console.log(event)
        console.log("key down test charCode",event.charCode);
        console.log("key down test key",event.key);
        console.log("key down test",event.keyCode);
        if((keyCode < 96 || keyCode > 105) && keyCode != 8){
        	console.log("key down test cancel");
            event.stopPropagation();
            event.preventDefault();
            return false;
        }
        return true;
    },
    render: function() {
        return <input onChange={this.props.onChangeFunction} onKeyDown={this.numberValidation} value={this.props.value} className="content-list-input"  placeholder={this.props.placeholder} />
    }
});

module.exports = NumberInput;