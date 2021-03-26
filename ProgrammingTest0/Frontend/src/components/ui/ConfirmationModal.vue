<template>
    <div class="modal fade confirmation-modal" :id="name" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">×</button>
                    <h4 class="modal-title">Static Backdrop</h4>
                </div>
                <div class="modal-body">
                    <p>You cannot click outside of this modal to close it.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
</template>

<script>
    export default {
        name: 'ConfirmationModal',
        props: ['name']
    };
</script>

<style scoped>
</style>