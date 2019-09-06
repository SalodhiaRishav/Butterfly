<template>
<div>
   <div style="background-color:#eee; height:100vh">
        <appNavigationbar></appNavigationbar>
        <div class="row">
            <div class="col-sm-3">
                <appSideBar></appSideBar> 
            </div>   
            <div class="col-sm-9" style="margin-top:30px;">
                <div class="row">
                  <div v-b-tooltip.hover title="Cases Created Last Week 20" class="col-sm-3 box" style="line-height:33px">                                 
                        <span class="heading" style="font-family:'Source Sans Pro', sans-serif; font-size:50px; font-weight:900">100</span><br>
                     <div>    
                        <span class="count" style="font-family:'Source Sans Pro', sans-serif; font-size:30px; font-weight:500" >Cases</span>  
                    </div>     
                 </div>  
                 <div v-b-tooltip.hover :title="declarationTitle" class="col-sm-3 box" style="line-height:33px; margin-left:30px; background: linear-gradient(to right, rgb(52, 181, 229), rgb(46, 132, 224));">                                     
                        <span class="heading" style="font-family:'Source Sans Pro', sans-serif; font-size:50px; font-weight:900">{{declarationCount}}</span><br>
                    <div >     
                        <span class="count" style="font-family:'Source Sans Pro', sans-serif; font-size:30px; font-weight:500" >Declaration</span>  
                    </div> 
                </div>                     
             </div>
             <div class="row" style="margin-top:20px;">
                <div class="col-sm-5 box" style="background:white">
                    <h1 style="color:black">Graph 1</h1>
                </div>
                <div class="col-sm-5 box" style="background: white; margin-left:22px">
                    <h1 style="color:black">Graph 2</h1>
                </div>
             </div>
         </div>
    </div>
   </div>
</div>

</template>
<script>
import SideBar from "./SideBar";
import Navigationbar from "./Navigationbar";
import httpClient from "./../utils/httpRequestWrapper";

export default {
    components:{
        appSideBar:SideBar,
        appNavigationbar:Navigationbar
    },
    data(){
        return {
            declarationCount: 0,
            declarationTitle:""
        }
    },
    created(){
        const url = '/declarationcount';
        httpClient.get(url)
        .then((response) =>{
            if(response.data.success === true){
                this.declarationCount = response.data.data;
            }
            else{
                console.log(response.data.message);
            }
        })
        .catch((error)=>{
            console.log(error);
        })
        const lastSevenDaysUrl = '/declarationsinsevendays'
        httpClient.get(lastSevenDaysUrl)
        .then((response)=>{
            if(response.data.success === true){
                   this.declarationTitle = `Declarations Created in Last seven days ${response.data.data}`; 
            }
            else{
                console.log(response.data.message);
            }
        })
        .catch(error => console.log(error)); 
        const statusCountUrl = '/getdeclarationstatuscount';
        httpClient.get(statusCountUrl)
        .then((response)=>{
            if(response.data.success === true){
                console.log(response.data.data);
            }
            else{
                console.log(response.data.message);
            }
        })
        .catch(error => console.log(error) );
    }
    
}
</script>
<style scoped>
@import url('https://fonts.googleapis.com/css?family=Source+Sans+Pro:200,400,900&display=swap');
@import url("./styles/dashboard2.css");
</style>