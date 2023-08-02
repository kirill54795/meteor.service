<script setup lang="ts">
import { PropType, toRef } from 'vue';
import { useField } from 'vee-validate';
import type { IFormSelectOption } from "./index.h";

const props = defineProps({
  value: {
    type: String,
    default: undefined,
  },
  name: {
    type: String,
    required: true,
  },
  label: {
    type: String,
    required: true,
  },
  successMessage: {
    type: String,
    default: '',
  },
  placeholder: {
    type: String,
    default: '',
  },
  options: {
    type: Array as PropType<Array<IFormSelectOption>>,
    required: true
  }
});

const name = toRef(props, 'name');
const value = toRef(props, 'value')

const {
  value: inputValue,
  handleBlur,
  handleChange,
} = useField(name, undefined, {
  initialValue: value,
});

</script>
<template>
  <a-select
    :options="options"
    :name="name"
    :id="name"
    :value="inputValue"
    :placeholder="placeholder"
    @change="handleChange"
    @blur="handleBlur"
  />
</template>

<style scoped>
  div {
    width: 100%;
  }
</style>