<template>
  <div>
    <div style="display: flex; width: 50%">
      <h2>{{ texto }}</h2>
      <div class="back">
        <slot></slot>
        <button v-show="btnBack" class="btn btnBack" @click="back()">
          Back
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    texto: String,
    btnBack: Boolean,
  },
  methods: {
    back() {
      this.$router.back();
    },
  },
};
</script>

<style scoped>
.back {
  width: 50%;
  position: absolute;
  margin-top: 15px;
}

.btnBack {
  float: right;
  background-color: rgb(199, 199, 199);
}
</style>
