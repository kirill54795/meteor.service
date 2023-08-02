<script setup lang="ts">
import { toRef } from 'vue';
import { useField } from 'vee-validate';

const props = defineProps({
  type: {
    type: String,
    default: 'text',
  },
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
  <a-input
    :name="name"
    :id="name"
    :value="inputValue"
    :placeholder="placeholder"
    @input="handleChange"
    @blur="handleBlur"
  />
</template>
