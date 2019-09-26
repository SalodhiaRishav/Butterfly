<template>
    <div>
         <div v-if="showTextBox" >
                <b-form-group
                  :label="label"
                   :label-for="id"
                >
                <b-form-input
                    :id=id
                    :value="value"
                     @input="$emit('input', $event)"
                  ></b-form-input>
                </b-form-group>
        </div>
    </div>
</template>

<script>
export default {
   
    props:{
        id:{
            type:String,
            required:true
        },
        label:{
            type:String,
            required:true
        },
        showTextBox:{
            type:Boolean,
            default:true
        },
        value: {
            default: null
        }
    },
}
</script>