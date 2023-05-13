// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#searchBtn").click(function () {
    var selectedCurrency = $("#selectList").val();
    getData(selectedCurrency);
})

function getData(selected)
{
    $.ajax({
        type: "GET",
        url: "https://localhost:7162/api/Currency/" + selected,
        success: function (result) {
            createChart(result);
        },
        error: function () {
            console.log("Error");
        }
        });
}

function createChart(data)
{
    d3.select("svg").remove();
    var margin = { top: 20, right: 30, bottom: 30, left: 40 },
        width = 600 - margin.left - margin.right,
        height = 400 - margin.top - margin.bottom;

    var svg = d3.select("#chart").append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    var x = d3.scaleTime().range([0, width]);
    var y = d3.scaleLinear().range([height, 0]);

    var parseTime = d3.timeParse("%m/%d/%Y");
    var formatTime = d3.timeFormat("%d/%m");

    data.forEach(function (d) {
        d.date = parseTime(d.date);
    });

    var line = d3.line()
        .x(function (d) { return x(d.date); })
        .y(function (d) { return y(d.forexBuying); });

    x.domain(d3.extent(data, function (d) { return d.date; }));
    y.domain(d3.extent(data, function (d) { return d.forexBuying; }));

    svg.append("path")
        .data([data])
        .attr("class", "line")
        .attr("d", line);

    svg.append("g")
        .attr("transform", "translate(0," + height + ")")
        .call(d3.axisBottom(x));

    svg.append("g")
        .call(d3.axisLeft(y));

    
}

$(document).ready(function ()
{
    var selectList = $("#selectList");

    $.ajax({
        type: "GET",
        url: "https://localhost:7162/api/Currency/get-currency-codes",
        success: function (result) {
            $.each(result, function (index, object) {
                selectList.append($("<option>", {
                    value: object,
                    text: object
                }));
            });
        },
        error: function () {
            console.log("Error");
        }
    });
})