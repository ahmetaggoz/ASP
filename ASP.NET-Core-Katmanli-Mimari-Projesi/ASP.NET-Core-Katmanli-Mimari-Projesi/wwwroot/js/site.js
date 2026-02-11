$(document).ready(function () {
    // Initialize tooltips
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });

    // Auto-hide alerts after 5 seconds
    $('.alert').each(function () {
        const alert = this;
        setTimeout(function () {
            $(alert).fadeOut('slow');
        }, 5000);
    });

    // Confirm delete operations
    $('.delete-btn').on('click', function (e) {
        const itemName = $(this).data('item-name');
        const itemType = $(this).data('item-type') || 'öğe';

        if (!confirm(`"${itemName}" ${itemType}sini silmek istediğinizden emin misiniz?`)) {
            e.preventDefault();
            return false;
        }
    });

    // Form validation enhancement
    $('form').on('submit', function (e) {
        const form = this;
        const submitBtn = $(form).find('button[type="submit"]');

        if (form.checkValidity()) {
            // Show loading state
            submitBtn.prop('disabled', true);
            const originalText = submitBtn.html();
            submitBtn.html('<span class="loading me-2"></span>İşleniyor...');

            // Re-enable button after 10 seconds (fallback)
            setTimeout(function () {
                submitBtn.prop('disabled', false);
                submitBtn.html(originalText);
            }, 10000);
        }
    });

    // Search functionality with debounce
    let searchTimeout;
    $('.search-input').on('input', function () {
        const input = this;
        const searchTerm = $(input).val();
        const targetUrl = $(input).data('search-url');
        const targetContainer = $(input).data('target-container');

        clearTimeout(searchTimeout);
        searchTimeout = setTimeout(function () {
            performSearch(targetUrl, searchTerm, targetContainer);
        }, 300);
    });

    function performSearch(url, term, container) {
        $.get(url, { searchTerm: term })
            .done(function (data) {
                $(container).html(data);
                $(container + ' .fade-in').addClass('fade-in');
            })
            .fail(function () {
                console.error('Arama işlemi başarısız oldu');
                showToast('Arama sırasında bir hata oluştu', 'error');
            });
    }

    // Toast notification system
    function showToast(message, type = 'info') {
        const toastHtml = `
            <div class="toast align-items-center text-white bg-${type === 'error' ? 'danger' : type} border-0" role="alert">
                <div class="d-flex">
                    <div class="toast-body">${message}</div>
                    <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
                </div>
            </div>`;

        let toastContainer = $('.toast-container');
        if (toastContainer.length === 0) {
            $('body').append('<div class="toast-container position-fixed top-0 end-0 p-3"></div>');
            toastContainer = $('.toast-container');
        }

        const toastElement = $(toastHtml);
        toastContainer.append(toastElement);

        const toast = new bootstrap.Toast(toastElement[0]);
        toast.show();

        toastElement.on('hidden.bs.toast', function () {
            $(this).remove();
        });
    }

    // Dynamic form field management
    $('.add-item-btn').on('click', function () {
        const template = $(this).data('template');
        const container = $(this).data('container');
        const index = $(container + ' .form-row').length;

        const newRow = $(template.replace(/\[0\]/g, `[${index}]`).replace(/_0_/g, `_${index}_`));
        $(container).append(newRow);

        // Initialize any new form elements
        newRow.find('select').trigger('chosen:updated');
    });

    // Remove dynamic form fields
    $(document).on('click', '.remove-item-btn', function () {
        $(this).closest('.form-row').remove();
        updateFormIndices();
    });

    function updateFormIndices() {
        $('.dynamic-form-container .form-row').each(function (index) {
            $(this).find('input, select, textarea').each(function () {
                const name = $(this).attr('name');
                const id = $(this).attr('id');

                if (name) {
                    $(this).attr('name', name.replace(/\[\d+\]/, `[${index}]`));
                }
                if (id) {
                    $(this).attr('id', id.replace(/_\d+_/, `_${index}_`));
                }
            });
        });
    }

    // Order status update
    $('.status-select').on('change', function () {
        const orderId = $(this).data('order-id');
        const newStatus = $(this).val();
        const updateUrl = $(this).data('update-url');

        if (confirm('Sipariş durumunu güncellemek istediğinizden emin misiniz?')) {
            $.post(updateUrl, {
                orderId: orderId,
                newStatus: newStatus,
                __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
            })
                .done(function (response) {
                    if (response.success) {
                        showToast('Sipariş durumu güncellendi', 'success');
                        location.reload();
                    } else {
                        showToast('Güncelleme sırasında bir hata oluştu', 'error');
                    }
                })
                .fail(function () {
                    showToast('Güncelleme sırasında bir hata oluştu', 'error');
                });
        } else {
            // Reset select to original value
            $(this).val($(this).data('original-value'));
        }
    });

    // Price formatting
    $('.price-input').on('input', function () {
        let value = $(this).val().replace(/[^\d.,]/g, '');
        value = value.replace(',', '.');
        $(this).val(value);
    });

    // Stock warning
    $('.stock-input').on('input', function () {
        const stock = parseInt($(this).val()) || 0;
        const warning = $(this).siblings('.stock-warning');

        if (stock <= 10) {
            warning.show().text(stock === 0 ? 'Stok tükendi!' : 'Düşük stok!');
            warning.removeClass('text-warning').addClass('text-danger');
        } else if (stock <= 50) {
            warning.show().text('Stok azalıyor');
            warning.removeClass('text-danger').addClass('text-warning');
        } else {
            warning.hide();
        }
    });

    // Initialize data tables if present
    if ($.fn.DataTable) {
        $('.data-table').DataTable({
            language: {
                url: '//cdn.datatables.net/plug-ins/1.11.5/i18n/tr.json'
            },
            responsive: true,
            pageLength: 25,
            order: [[0, 'desc']]
        });
    }
});

// Global utility functions
window.ECommerceApp = {
    formatCurrency: function (amount) {
        return new Intl.NumberFormat('tr-TR', {
            style: 'currency',
            currency: 'TRY'
        }).format(amount);
    },

    formatDate: function (date) {
        return new Intl.DateTimeFormat('tr-TR', {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit',
            hour: '2-digit',
            minute: '2-digit'
        }).format(new Date(date));
    },

    showLoading: function (element) {
        $(element).prop('disabled', true).html('<span class="loading me-2"></span>Yükleniyor...');
    },

    hideLoading: function (element, originalText) {
        $(element).prop('disabled', false).html(originalText);
    }
};