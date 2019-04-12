//this is a reusable component encapsulating the elements for presenting 
//an address data to users and let users to enter new or edit existing addresses.
//Since it is always as a part of another larger component, it is best implemented as a stateless component.
//It displays the address data received from its parent and sends the changed address to its parent via its properties.

var Address = React.createClass({
    provinces: [    //creating an array of provinces (key:code and value:province)
        { code: "ON", name: "Ontario" },
        { code: "BC", name: "British Columbia" },
        { code: "QC", name: "Quebec" },
        { code: "ALB", name: "Alberta" },
        { code: "NS", name: "Nova Scotia" },
        { code: "NB", name: "New Brunswick" },
        { code: "MB", name: "Manitoba" },
        { code: "PEI", name: "Prince Edward Island" },
        { code: "NL", name: "Newfoundland and Labrador" },
        { code: "SK", name: "Saskatchewan" }
    ],
    //creates the options for the drop down list...key and value are the code and it will display the name
    makeProvinceOptions: function (x) {
        return <option key={x.code} value={x.code}>{x.name}</option >
    },

    handlerChange: function (e) {
        var addr = this.props.address;

        if (e.target.id == "txtStreet")
            addr.street = e.target.value;
        else if (e.target.id == "txtCity")
            addr.city = e.target.value;
        else if (e.target.id == "drpProvince")
            addr.province = e.target.value;
        else if (e.target.id == "txtPostalCode")
            addr.postalCode = e.target.value;

        this.props.onAddressChange(addr);
    },

    //adding CSS
    render: function () {
        var addrBlockStyle = {
            marginBottom: 10,
            marginTop: 5,
            paddingBottom: 10,
            paddingTop: 5
        };

        return (
            <div style={addrBlockStyle}>
                <div className="row">
                    <div className="col-md-2 label-align"><label htmlFor="txtStreet">Street:</label> </div>
                    <div className="col-md-10">
                        <input type="text" id="txtStreet" className="form-control" style={{ width: "100%" }}
                            onChange={this.handlerChange} value={this.props.address.street} />
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-2 label-align"><label htmlFor="txtCity">City:</label></div>
                    <div className="col-md-10">
                        <input type="text" id="txtCity" className="form-control" style={{ width: "100%" }}
                            onChange={this.handlerChange} value={this.props.address.city} /></div>
                </div>
                <div className="row">
                    <div className="col-md-2 label-align"><label htmlFor="txtProvince">Province:</label> </div>
                    <div className="col-md-5">
                        <select type="text" id="drpProvince" className="form-control" style={{ width: "100%" }}
                            onChange={this.handlerChange} value={this.props.address.province}>
                            {this.provinces.map(this.makeProvinceOptions)}
                        </select>
                    </div>
                    <div className="col-md-2 label-align"><label htmlFor="txtPostalCode">Postal Code:</label></div>
                    <div className="col-md-3">
                        <input type="text" id="txtPostalCode" className="form-control" style={{ width: "100%" }}
                            onChange={this.handlerChange} value={this.props.address.postalCode} /></div>
                </div>
            </div>
        );
    }
});
