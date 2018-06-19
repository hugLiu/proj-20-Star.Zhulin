var clientWidth = document.body.clientWidth;
var currentWidth = (clientWidth - 120) / 3;
var styleLook = "width:" + currentWidth + "px;", styleDownload = "width:" + currentWidth + "px;", styleNewestpt = "width:" + currentWidth + "px;";
var countDownload = 10, countLook = 10;
//获得柱状图数据
function GetHistogramData() {
    var histogramTypeName = [], histogramCount = [];
    var _param = {
        "fields": {
            "groups.ep.producttype": 1
        },
        "grouprule": {
            "Top": 0,
            "GFields": [
                "ep.producttype"
            ]
        }
    };
    var _paramJson = JSON.stringify(_param);  
    $.ajax({
        url: "/Document/GetMatchData",
        type: "get",
        data: { param: _paramJson },
        success: function (result) { 
            var data = JSON.parse(result);
            var producttype = data.groups["ep.producttype"];
            for (var k in producttype) {
                histogramTypeName.push(k);
                histogramCount.push(producttype[k]);
            }
            initHistogramChart(histogramTypeName, histogramCount);
        },
        error: function (result) {
            console.log(result);
        }
    }); 
}

function initHistogramChart(histogramTypeName, histogramCount) {
    // 基于准备好的dom，初始化echarts实例
    var myChart = echarts.init(document.getElementById('chart_1'));
    // 指定图表的配置项和数据
    var option = {
        title: {
            text: ''
        },
        tooltip: {},
        legend: {
            data: []
        },
        xAxis: {
            data: histogramTypeName
            //data:["A","B"]
        },
        yAxis: {},
        series: [{
            name: '',
            type: 'bar',
            data: histogramCount,
            //data:[1,2]
        }]
    };
    // 使用刚指定的配置项和数据显示图表。
    myChart.setOption(option);
}
//获得饼图数据
function GetPieData() {
    var pieTypeName = [], pieCount = [];
    var _param2 = {
        "fields": {
            "groups.ep.theme": 1
        },
        "grouprule": {
            "Top": 0,
            "GFields": [
                "ep.theme"
            ]
        }
    };
    var _paramJson2 = JSON.stringify(_param2); 
    $.ajax({
        url: "/Document/GetMatchData",
        type: "get",
        data: { param: _paramJson2 },
        success: function (result) {
            var data = JSON.parse(result);
            var theme = data.groups["ep.theme"];
            for (var k in theme) {
                //饼图数据
                pieTypeName.push(k);
                pieCount.push({
                    "value": theme[k],
                    "name": k
                });
            }
            //initPieChart(pieTypeName, pieCount);
        },
        error: function (result) {
            console.log(result);
        }
    });
}

function initPieChart(pieTypeName, pieCount) {
    var myChart = echarts.init(document.getElementById('chart_2'));
    var option = {
        title: {
            text: '',
            subtext: '',
            x: 'center'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'vertical',
            x: 'left',
            data: pieTypeName
        },
        //toolbox: {
        //    show: true,
        //    feature: {
        //        mark: { show: true },
        //        dataView: { show: true, readOnly: false },
        //        magicType: {
        //            show: true,
        //            type: ['pie', 'funnel'],
        //            option: {
        //                funnel: {
        //                    x: '25%',
        //                    width: '50%',
        //                    funnelAlign: 'left',
        //                    max: 1548
        //                }
        //            }
        //        },
        //        restore: { show: true },
        //        saveAsImage: { show: true }
        //    }
        //},
        //calculable: true,
        series: [
            {
                name: '',
                type: 'pie',
                radius: '55%',
                center: ['50%', '60%'],
                data: pieCount
            }
        ]
    };
    myChart.setOption(option);
}

$(document).ready(function () {
    $('.navbar-nav li a').each(function () {
        if ($($(this))[0].href == String(window.location)) {
            $("#homepage").removeClass('active');
            $(this).parent().addClass('active');
        }
    });
    GetHistogramData();
    //GetPieData();
});