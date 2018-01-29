var Model;
function init(json) {
    Model = json;
    console.log(Model);
}
$(document).ready(function () {
    //act sales
    var i = 0;
    $(".amount-sale").each(function () {
        var ctx = document.getElementById($(this).attr('id')).getContext("2d");
        //console.log(ctx);
        var data = {
            datasets: [{
                data: [Model.AmountSold[i].Value[0], Model.AmountSold[i].Value[1]],
                backgroundColor: [
                    "#1ed614",
                    "#36a2eb"
                ]
            }],
            labels: [
                'Sold',
                'Total Seats'
            ]
        };
        console.log(data);
        var options = {};
        new Chart(ctx, {
            type: 'pie',
            data: data,
            options: options
        });
        i++;
    });
    var ctx = document.getElementById("Daily-sale").getContext("2d");
    //console.log(ctx);
    var data = [];
    var labels = [];
    for (var j = 0;j<Model.DailySales.length;j++) {
        data.push(Model.DailySales[j].Value);
        labels.push(Model.DailySales[j].Key);
        console.log(Model.DailySales[j]);
    }
    console.log(labels);
    var dataSet = {
        datasets: [{
            label: "Daily sales",
            data: data,
            backgroundColor: [
                "#1ed614",
                "#1ed614",
                "#1ed614",
                "#1ed614",
                "#1ed614",
                "#1ed614",
                "#1ed614",
                "#1ed614",
                "#1ed614",
                "#1ed614",
                "#1ed614",
                "#1ed614",
                "#1ed614",
                "#1ed614"
            ]
        }],
        labels: labels
    };
    console.log(dataSet);
    var options = { scales: { yAxes: [{ ticks: { beginAtZero : true } }] } };
    new Chart(ctx, {
        type: 'bar',
        data: dataSet,
        options: options
    });
});